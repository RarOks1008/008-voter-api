using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Voter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public MailController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // POST api/<MailController>
        [HttpPost]
        public IActionResult Post([FromBody] MailDto dto,
            [FromServices] ISendMailCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return Ok();
        }
    }
}
