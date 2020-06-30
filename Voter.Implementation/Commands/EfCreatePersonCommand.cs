using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.Application.Exceptions;
using Voter.EfDataAccess;
using Voter.Implementation.Validators;

namespace Voter.Implementation.Commands
{
    public class EfCreatePersonCommand : ICreatePersonCommand
    {
        private readonly VoterContext _context;
        private readonly CreatePersonValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreatePersonCommand(VoterContext context, CreatePersonValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 4;
        public string Name => "Create Person";
        public void Execute(PersonDto request)
        {
            _validator.ValidateAndThrow(request);

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            var personRegion = _context.Regions.Find(request.RegionId);
            if (actorRegion.StateId != personRegion.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }
            var passHash = HashHelper.ConvertPasswordFormat(request.Password, 0xFF);

            _context.Persons.Add(new Domain.Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PersonalId = request.PersonalId,
                Password = passHash,
                RoleId = request.RoleId,
                RegionId = request.RegionId
            });
            _context.SaveChanges();
        }
    }
}
