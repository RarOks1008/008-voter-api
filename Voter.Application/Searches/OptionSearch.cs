﻿using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Queries;

namespace Voter.Application.Searches
{
    public class OptionSearch : PagedSearch
    {
        public string SearchName { get; set; }
    }
}
