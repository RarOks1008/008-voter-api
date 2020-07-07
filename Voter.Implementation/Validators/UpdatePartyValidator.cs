using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class UpdatePartyValidator : AbstractValidator<PartyDto>
    {
        public UpdatePartyValidator(VoterContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                .Must((dto, n) => !context.Partys.Any(party => party.Name == n && party.Id != dto.Id))
                .WithMessage("There can not be two regions with the same name.");
        }
    }
}
