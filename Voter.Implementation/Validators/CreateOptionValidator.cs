using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class CreateOptionValidator : AbstractValidator<OptionDto>
    {
        public CreateOptionValidator(VoterContext context)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Info).NotEmpty();
        }
    }
}
