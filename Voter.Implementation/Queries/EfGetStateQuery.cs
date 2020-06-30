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
    public class EfGetStateQuery : IGetStateQuery
    {
        private readonly VoterContext _context;
        private readonly IMapper _mapper;
        public EfGetStateQuery(VoterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Get State";

        public StateDto Execute(int search)
        {
            var state = _context.States.Find(search);
            if (state == null)
            {
                throw new EntityNotFoundException(search, typeof(State));
            }

            return _mapper.Map<StateDto>(state);
        }
    }
}
