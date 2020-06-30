using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.Application.Queries;
using Voter.Application.Searches;
using Voter.EfDataAccess;
using Voter.Implementation.Extensions;

namespace Voter.Implementation.Queries
{
    public class EfGetStatesQuery : IGetStatesQuery
    {
        private readonly VoterContext _context;
        private readonly IMapper _mapper;

        public EfGetStatesQuery(VoterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "State Search";

        public PagedResponse<StateDto> Execute(StateSearch search)
        {
            var query = _context.States.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<StateDto, Domain.State>(search, _mapper);
        }
    }
}
