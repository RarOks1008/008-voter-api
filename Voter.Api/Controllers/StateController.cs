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
using Voter.Application.Exceptions;
using Voter.Application.Queries;
using Voter.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Voter.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public StateController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<StateController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] StateSearch search,
            [FromServices] IGetStatesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetStateQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<StateController>
        [HttpPost]
        public IActionResult Post([FromBody] StateDto dto,
            [FromServices] ICreateStateCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StateDto dto,
            [FromServices] IUpdateStateCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteStateCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
