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
    public class EfCreateRegionCommand : ICreateRegionCommand
    {
        private readonly VoterContext _context;
        private readonly CreateRegionValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateRegionCommand(VoterContext context, CreateRegionValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 8;

        public string Name => "Create Region";

        public void Execute(RegionDto request)
        {
            _validator.ValidateAndThrow(request);

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);

            _context.Regions.Add(new Domain.Region
            {
                Name = request.Name,
                StateId = actorRegion.StateId
            });
            _context.SaveChanges();
        }
    }
}
