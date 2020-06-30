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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Voter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonVoteController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public PersonVoteController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<PersonVoteController>
        [HttpGet]
        public IActionResult Get(
            [FromServices] IGetPersonVoteQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, null));
        }

        // POST api/<PersonVoteController>
        [HttpPost]
        public IActionResult Post([FromBody] PersonVoteDto dto,
            [FromServices] IPersonVoteCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
