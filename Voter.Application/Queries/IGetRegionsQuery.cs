using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.Application.Searches;

namespace Voter.Application.Queries
{
    public interface IGetRegionsQuery : IQuery<RegionSearch, PagedResponse<RegionDto>>
    {
    }
}
