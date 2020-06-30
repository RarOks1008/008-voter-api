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
    public class EfGetOptionsQuery : IGetOptionsQuery
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfGetOptionsQuery(VoterContext context, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Option Search";

        public PagedResponse<OptionDto> Execute(OptionSearch search)
        {
            var query = _context.Options.AsQueryable();
            if (!string.IsNullOrEmpty(search.SearchName) || !string.IsNullOrWhiteSpace(search.SearchName))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.SearchName.ToLower()) || x.Info.ToLower().Contains(search.SearchName.ToLower()));
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);

            query = query.Where(x => x.StateId == actorRegion.StateId);

            return query.Paged<OptionDto, Domain.Option>(search, _mapper);
        }
    }
}
