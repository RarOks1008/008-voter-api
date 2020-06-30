using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.Domain;
using Voter.EfDataAccess;

namespace Voter.Implementation.Commands
{
    public class EfUploadFileCommand : IUploadFileCommand
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor actor;

        public EfUploadFileCommand(IApplicationActor actor, VoterContext context)
        {
            this.actor = actor;
            _context = context;
        }

        public int Id => 6;

        public string Name => "Upload File";

        public void Execute(ReportDto request)
        {
            var pic = new Report
            {
                Name = request.Name,
                Text = request.Text,
                Actor = actor.Identity
            };
            _context.Reports.Add(pic);
            _context.SaveChanges();
        }
    }
}
