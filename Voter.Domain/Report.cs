using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Domain
{
    public class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Actor { get; set; }
    }
}
