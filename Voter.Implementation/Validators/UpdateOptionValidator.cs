using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class UpdateOptionValidator : AbstractValidator<OptionDto>
    {
        public UpdateOptionValidator(VoterContext context)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Info).NotEmpty();
            RuleFor(x => x.PartyId)
                .Must(id => context.Partys.Any(p => p.Id == id) || id == null)
                .WithMessage("Party must exist");
        }
    }
}
