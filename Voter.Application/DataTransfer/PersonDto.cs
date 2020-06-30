using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Application.DataTransfer
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PersonalId { get; set; }
        public string Password { get; set; }
        public int RoleId => 1;
        public int RegionId { get; set; }
    }
}
