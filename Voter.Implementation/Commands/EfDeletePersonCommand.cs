using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.Exceptions;
using Voter.Domain;
using Voter.EfDataAccess;

namespace Voter.Implementation.Commands
{
    public class EfDeletePersonCommand : IDeletePersonCommand
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;

        public EfDeletePersonCommand(VoterContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 7;

        public string Name => "Delete Person";

        public void Execute(int request)
        {
            var person = _context.Persons.Find(request);

            if(person == null)
            {
                throw new EntityNotFoundException(request, typeof(Person));
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            var personObj = _context.Persons.Find(person.Id);
            var personRegion = _context.Regions.Find(personObj.RegionId);
            if (actorRegion.StateId != personRegion.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }

            var role = _context.Roles.Find(person.RoleId);
            if(role.Name != "Voter")
            {
                throw new PersonIsAdminException(request);
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
