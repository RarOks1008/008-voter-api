using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.Application.Exceptions;
using Voter.Application.Queries;
using Voter.Domain;
using Voter.EfDataAccess;

namespace Voter.Implementation.Queries
{
    public class EfGetVotingResult : IGetVotingResult
    {
        private readonly VoterContext _context;

        public EfGetVotingResult(VoterContext context)
        {
            _context = context;
        }

        public int Id => 26;

        public string Name => "Get Voting Result";

        public IEnumerable<ShowSingleVotingDto> Execute(int search)
        {
            var state = _context.States.Find(search);
            if (state == null)
            {
                throw new EntityNotFoundException(search, typeof(State));
            }
            var query = _context.Persons.Include(x => x.Region).Include(x => x.Option)
                .ThenInclude(x => x.State)
                .GroupBy(x => new { x.OptionId, x.Option.Name, x.Option.Info, StateId = x.Region.State.Id, StateName = x.Region.State.Name, x.RegionId, RegionName = x.Region.Name })
                .Select(g => new { KeyValue = g.Key, CountNumber = g.Count() })
                .AsQueryable();
            query = query.Where(w => w.KeyValue.StateId == search);

            var response = query.Select(x => new ShowSingleVotingDto
            {
                CountNumber = x.CountNumber,
                Id = (int)x.KeyValue.OptionId,
                Info = x.KeyValue.Info,
                Name = x.KeyValue.Name,
                RegionId = x.KeyValue.RegionId,
                RegionName = x.KeyValue.RegionName,
                StateId = x.KeyValue.StateId,
                StateName = x.KeyValue.StateName
            }).ToList();
            return response;
        }
    }
}
