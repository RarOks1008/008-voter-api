using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;
using Voter.Implementation.Validators;

namespace Voter.Implementation.Commands
{
    public class EfGrantRoleCommand : IGrantRoleCommand
    {
        private readonly VoterContext _context;
        private readonly GrantRoleValidator _validator;

        public EfGrantRoleCommand(VoterContext context, GrantRoleValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Grant Role";

        public void Execute(PersonRoleDto request)
        {
            _validator.ValidateAndThrow(request);
            var person = _context.Persons.Find(request.Id);
            person.RoleId = request.RoleId;
            _context.SaveChanges();
        }
    }
}
