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
    public class EfUpdatePersonCommand : IUpdatePersonCommand
    {
        private readonly VoterContext _context;
        private readonly UpdatePersonValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdatePersonCommand(VoterContext context, UpdatePersonValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 19;

        public string Name => "Update Person";

        public void Execute(PersonDto request)
        {
            _validator.ValidateAndThrow(request);
            var person = _context.Persons.Find(request.Id);
            if (person == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Person));
            }
            var role = _context.Roles.Find(person.RoleId);
            if (role.Name != "Voter")
            {
                throw new PersonIsAdminException(request.Id);
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            var personObj = _context.Persons.Find(person.Id);
            var personRegion = _context.Regions.Find(personObj.RegionId);
            if (actorRegion.StateId != personRegion.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }
            var requestRegion = _context.Regions.Find(request.RegionId);
            if (actorRegion.StateId != requestRegion.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }
            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Address = request.Address;
            person.PersonalId = request.PersonalId;
            person.RegionId = request.RegionId;
            _context.SaveChanges();
        }
    }
}
