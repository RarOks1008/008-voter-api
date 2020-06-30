using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Domain
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
