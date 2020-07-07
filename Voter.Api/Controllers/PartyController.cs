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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PartyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PartyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
