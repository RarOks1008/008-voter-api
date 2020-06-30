using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Domain
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
