using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.Application.Exceptions;
using Voter.Domain;
using Voter.EfDataAccess;
using Voter.Implementation.Validators;

namespace Voter.Implementation.Commands
{
    public class EfUpdateRegionCommand : IUpdateRegionCommand
    {
        private readonly VoterContext _context;
        private readonly UpdateRegionValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateRegionCommand(VoterContext context, UpdateRegionValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 21;

        public string Name => "Update Region";

        public void Execute(RegionDto request)
        {
            _validator.ValidateAndThrow(request);
            var region = _context.Regions.Find(request.Id);
            if (region == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Region));
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            if (actorRegion.StateId != region.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }

            region.Name = request.Name;
            _context.SaveChanges();
        }
    }
}
