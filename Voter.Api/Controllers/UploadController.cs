using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public UploadController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/<UploadController>
        [HttpGet]
        public IActionResult Get([FromBody] ReportSearch search,
            [FromServices] IGetReportsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // POST api/<UploadController>
        [HttpPost]
        public IActionResult Post([FromForm] UploadDto dto,
            [FromServices] IUploadFileCommand command)
        {
            var newFileName = "";
            if (dto.File != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(dto.File.FileName);
                newFileName = guid + extension;
                var path = Path.Combine("wwwroot", "Files", newFileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    dto.File.CopyTo(fileStream);
                }
            }

            var fileDto = new ReportDto
            {
                Name = newFileName,
                Text = dto.Text
            };

            executor.ExecuteCommand(command, fileDto);
            return Ok();
        }
    }
    public class UploadDto
    {
        public IFormFile File { get; set; }
        public string Text { get; set; }
    }
}
