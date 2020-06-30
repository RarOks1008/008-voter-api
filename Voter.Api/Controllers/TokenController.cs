using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voter.Api.Core;
using Voter.Application;
using Voter.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Voter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager manager;
        private readonly IUseCaseLogger logger;

        public TokenController(JwtManager manager, IUseCaseLogger logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        // POST api/<TokenController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            logger.Log(null, null, request);
            var token = manager.MakeToken(request.Username, HashHelper.ConvertPasswordFormat(request.Password, 0xFF));
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
