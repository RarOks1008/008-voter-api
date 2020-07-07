using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voter.Application;
using Voter.Application.Queries;
using Voter.Application.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Voter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public LogController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetLogsQuery query,
            [FromBody] LogSearch search)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
    }
}
