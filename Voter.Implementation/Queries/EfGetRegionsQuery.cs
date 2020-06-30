using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application;
using Voter.Application.DataTransfer;
using Voter.Application.Queries;
using Voter.Application.Searches;
using Voter.EfDataAccess;
using Voter.Implementation.Extensions;

namespace Voter.Implementation.Queries
{
    public class EfGetRegionsQuery : IGetRegionsQuery
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfGetRegionsQuery(VoterContext context, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Region Search";

        public PagedResponse<RegionDto> Execute(RegionSearch search)
        {
            var query = _context.Regions.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            query = query.Where(x => x.StateId == actorRegion.StateId);

            return query.Paged<RegionDto, Domain.Region>(search, _mapper);
        }
    }
}
