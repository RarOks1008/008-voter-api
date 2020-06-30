using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Voter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrantAdminController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public GrantAdminController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST api/<GrantAdminController>
        [HttpPost]
        public IActionResult Post([FromBody] PersonRoleDto dto,
            [FromServices] IGrantRoleCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
