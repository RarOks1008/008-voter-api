using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.Application.Queries;
using Voter.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Voter.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public PersonController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] PersonSearch search,
            [FromServices] IGetPersonsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetPersonQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody] PersonDto dto,
            [FromServices] ICreatePersonCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonDto dto,
            [FromServices] IUpdatePersonCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePersonCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
