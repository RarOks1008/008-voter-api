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
    public class EfGetReportsQuery : IGetReportsQuery
    {
        private readonly VoterContext _context;
        private readonly IMapper _mapper;

        public EfGetReportsQuery(VoterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 33;

        public string Name => "Get Reports";

        public PagedResponse<ReportDto> Execute(ReportSearch search)
        {
            var query = _context.Reports.AsQueryable();
            return query.Paged<ReportDto, Domain.Report>(search, _mapper);
        }
    }
}
