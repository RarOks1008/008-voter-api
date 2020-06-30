using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Application.Queries
{
    public interface IGetVotingResults : IQuery<object, IEnumerable<ShowVotingDto>>
    {
    }
}
