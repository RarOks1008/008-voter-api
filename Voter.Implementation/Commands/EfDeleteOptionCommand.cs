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
    public class EfDeleteOptionCommand : IDeleteOptionCommand
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;

        public EfDeleteOptionCommand(VoterContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 13;

        public string Name => "Delete Option";

        public void Execute(int request)
        {
            var option = _context.Options.Find(request);
            if (option == null)
            {
                throw new EntityNotFoundException(request, typeof(Option));
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);

            if (actorRegion.StateId != option.StateId)
            {
               throw new NotAllowedToViewOrEditException();
            }

            _context.Options.Remove(option);
            _context.SaveChanges();
        }
    }
}
