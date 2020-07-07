using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application;
using Voter.Application.DataTransfer;
using Voter.Application.Exceptions;
using Voter.Application.Queries;
using Voter.Domain;
using Voter.EfDataAccess;

namespace Voter.Implementation.Queries
{
    public class EfGetRegionQuery : IGetRegionQuery
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfGetRegionQuery(VoterContext context, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 16;

        public string Name => "Get Region";

        public RegionDto Execute(int search)
        {
            var region = _context.Regions.Include(x => x.State).FirstOrDefault(s => s.Id == search);
            if (region == null)
            {
                throw new EntityNotFoundException(search, typeof(Region));
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            if (actorRegion.StateId != region.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }

            return _mapper.Map<RegionDto>(region);
        }
    }
}
