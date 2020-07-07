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
using Voter.Application.Searches;
using Voter.EfDataAccess;
using Voter.Implementation.Extensions;

namespace Voter.Implementation.Queries
{
    public class EfGetPersonsQuery : IGetPersonsQuery
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfGetPersonsQuery(VoterContext context, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Person Search";

        public PagedResponse<PersonDto> Execute(PersonSearch search)
        {
            var query = _context.Persons.Include(x => x.Region).AsQueryable();
            if (!string.IsNullOrEmpty(search.SearchName) || !string.IsNullOrWhiteSpace(search.SearchName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.SearchName.ToLower()) || x.LastName.ToLower().Contains(search.SearchName.ToLower()));
            }
            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            if (search.RegionId != 0)
            {
                query = query.Where(x => x.RegionId == search.RegionId);
                var searchRegion = _context.Regions.Find(search.RegionId);
                if (actorRegion.StateId != searchRegion.StateId)
                {
                    throw new NotAllowedToViewOrEditException();
                }
            }

            query = query.Where(x => x.Region.StateId == actorRegion.StateId);

            return query.Paged<PersonDto, Domain.Person>(search, _mapper);
        }
    }
}
