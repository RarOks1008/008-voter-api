using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.Application.Exceptions;
using Voter.Application.Queries;
using Voter.Domain;
using Voter.EfDataAccess;

namespace Voter.Implementation.Queries
{
    public class EfGetPartyQuery : IGetPartyQuery
    {
        private readonly VoterContext _context;
        private readonly IMapper _mapper;

        public EfGetPartyQuery(VoterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 29;

        public string Name => "Get Query";

        public PartyDto Execute(int search)
        {
            var party = _context.Partys.Find(search);
            if (party == null)
            {
                throw new EntityNotFoundException(search, typeof(Party));
            }
            return _mapper.Map<PartyDto>(party);
        }
    }
}
