using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class CreateStateValidator : AbstractValidator<StateDto>
    {
        public CreateStateValidator(VoterContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(name => !context.States.Any(s => s.Name == name))
                .WithMessage("State must have a unique name.");
        }
    }
}
