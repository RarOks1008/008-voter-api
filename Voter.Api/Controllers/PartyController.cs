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
    public class PartyController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public PartyController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<PartyController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] PartySearch search,
            [FromServices] IGetPartysQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<PartyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetPartyQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<PartyController>
        [HttpPost]
        public IActionResult Post([FromBody] PartyDto dto,
            [FromServices] ICreatePartyCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<PartyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PartyDto dto,
            [FromServices] IUpdatePartyCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<PartyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePartyCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
