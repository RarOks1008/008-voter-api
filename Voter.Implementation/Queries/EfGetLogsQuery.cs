using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.Application.Queries;
using Voter.Application.Searches;
using Voter.EfDataAccess;
using Voter.Implementation.Extensions;

namespace Voter.Implementation.Queries
{
    public class EfGetLogsQuery : IGetLogsQuery
    {
        private readonly VoterContext _context;
        private readonly IMapper _mapper;

        public EfGetLogsQuery(VoterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 34;

        public string Name => "Get Logs";

        public PagedResponse<LogDto> Execute(LogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();
            return query.Paged<LogDto, Domain.UseCaseLog>(search, _mapper);
        }
    }
}
