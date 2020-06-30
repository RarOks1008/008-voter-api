using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.Application.Queries;
using Voter.EfDataAccess;

namespace Voter.Implementation.Queries
{
    public class EfGetVotingResults : IGetVotingResults
    {
        private readonly VoterContext _context;

        public EfGetVotingResults(VoterContext context)
        {
            _context = context;
        }

        public int Id => 25;

        public string Name => "Get Voting Results";

        public IEnumerable<ShowVotingDto> Execute(object search)
        {
            var query = _context.Persons.Include(x => x.Region).Include(x => x.Option)
                .ThenInclude(x => x.State)
                .GroupBy(x => new { x.OptionId, x.Option.Name, x.Option.Info, x.Region.State.Id })
                .Select(g => new { KeyValue = g.Key, CountNumber = g.Count() });

            var response = query.Select(x => new ShowVotingDto
            {
                CountNumber = x.CountNumber,
                Id = (int)x.KeyValue.OptionId,
                Info = x.KeyValue.Info,
                Name = x.KeyValue.Name,
                StateId = x.KeyValue.Id
            }).ToList();
            return response;
        }
    }
}
