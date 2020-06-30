using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voter.Application;

namespace Voter.Api.Core
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Unauthorized";

        public IEnumerable<int> AllowedUseCases => new List<int> { 5 };
    }
}
