using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Voter.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PersonalId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int RegionId { get; set; }
        public int? OptionId { get; set; }
        public virtual Region Region { get; set; }
        public virtual Role Role { get; set; }
        public virtual Option Option { get; set; }
    }
}
