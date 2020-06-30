using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Domain
{
    public class RoleUseCase
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UseCaseId { get; set; }
        public virtual Role Role { get; set; }
    }
}
