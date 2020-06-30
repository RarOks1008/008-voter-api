using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public OptionController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<OptionController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] OptionSearch search,
            [FromServices] IGetOptionsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<OptionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOptionQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<OptionController>
        [HttpPost]
        public IActionResult Post([FromBody] OptionDto dto,
            [FromServices] ICreateOptionCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<OptionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OptionDto dto,
            [FromServices] IUpdateOptionCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<OptionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOptionCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
