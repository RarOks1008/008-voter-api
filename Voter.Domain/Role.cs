using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<RoleUseCase> RoleUseCases { get; set; }
    }
}
