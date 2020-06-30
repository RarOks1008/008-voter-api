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
    public class EfUpdateOptionCommand : IUpdateOptionCommand
    {
        private readonly VoterContext _context;
        private readonly UpdateOptionValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateOptionCommand(VoterContext context, UpdateOptionValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 22;

        public string Name => "Update Option";

        public void Execute(OptionDto request)
        {
            _validator.ValidateAndThrow(request);
            var option = _context.Options.Find(request.Id);
            if (option == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Option));
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);

            if (actorRegion.StateId != option.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }

            option.Name = request.Name;
            option.Info = request.Info;
            _context.SaveChanges();
        }
    }
}
