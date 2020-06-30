using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class GrantRoleValidator : AbstractValidator<PersonRoleDto>
    {
        public GrantRoleValidator(VoterContext context)
        {
            RuleFor(x => x.Id).NotEmpty()
                .Must(id => context.Persons.Any(x => x.Id == id))
                .WithMessage("You must send a valid user id.");
            RuleFor(x => x.RoleId).NotEmpty()
                .Must(id => context.Roles.Any(x => x.Id == id))
                .WithMessage("You must send a valid role id.");
        }
    }
}
