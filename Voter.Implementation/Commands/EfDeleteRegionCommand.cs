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
    public class EfDeleteRegionCommand : IDeleteRegionCommand
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;

        public EfDeleteRegionCommand(VoterContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 9;

        public string Name => "Delete Region";

        public void Execute(int request)
        {
            var region = _context.Regions.Find(request);
            if (region == null)
            {
                throw new EntityNotFoundException(request, typeof(Region));
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            if (actorRegion.StateId != region.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }

            _context.Regions.Remove(region);
            _context.SaveChanges();
        }
    }
}
