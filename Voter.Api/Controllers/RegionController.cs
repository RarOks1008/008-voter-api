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
    public class RegionController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public RegionController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<RegionController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] RegionSearch search,
            [FromServices] IGetRegionsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<RegionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRegionQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<RegionController>
        [HttpPost]
        public IActionResult Post([FromBody] RegionDto dto,
            [FromServices] ICreateRegionCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RegionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RegionDto dto,
            [FromServices] IUpdateRegionCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<RegionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRegionCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
