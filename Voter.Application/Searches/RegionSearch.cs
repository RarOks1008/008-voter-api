﻿using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Queries;

namespace Voter.Application.Searches
{
    public class RegionSearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
