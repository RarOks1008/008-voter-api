using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;
using Voter.Implementation.Validators;

namespace Voter.Implementation.Commands
{
    public class EfCreateOptionCommand : ICreateOptionCommand
    {
        private readonly VoterContext _context;
        private readonly CreateOptionValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateOptionCommand(VoterContext context, CreateOptionValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 12;

        public string Name => "Create Option";

        public void Execute(OptionDto request)
        {
            _validator.ValidateAndThrow(request);
            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            _context.Options.Add(new Domain.Option
            {
                Name = request.Name,
                Info = request.Info,
                StateId = actorRegion.StateId
            });
            _context.SaveChanges();
        }
    }
}
