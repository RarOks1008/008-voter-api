using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Queries;

namespace Voter.Application.Searches
{
    public class PersonSearch : PagedSearch
    {
        public string SearchName { get; set; }
        public int RoleId { get; set; }
        public int RegionId { get; set; }
    }
}
