using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voter.Application;
using Voter.Application.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Voter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowVotingController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public ShowVotingController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<ShowVotingController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetVotingResults query)
        {
            return Ok(_executor.ExecuteQuery(query, null));
        }

        // GET api/<ShowVotingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetVotingResult query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }
    }
}
