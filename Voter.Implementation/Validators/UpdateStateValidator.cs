using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class UpdateStateValidator : AbstractValidator<StateDto>
    {
        public UpdateStateValidator(VoterContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must((dto, name) => !context.States.Any(s => s.Name == name && s.Id != dto.Id))
                .WithMessage("State must have a unique name.");
        }
    }
}
