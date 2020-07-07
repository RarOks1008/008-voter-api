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
    public class EfGetPartysQuery : IGetPartysQuery
    {
        private readonly VoterContext _context;
        private readonly IMapper _mapper;

        public EfGetPartysQuery(VoterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 28;

        public string Name => "Get Parties";

        public PagedResponse<PartyDto> Execute(PartySearch search)
        {
            var query = _context.Partys.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            return query.Paged<PartyDto, Domain.Party>(search, _mapper);
        }
    }
}
