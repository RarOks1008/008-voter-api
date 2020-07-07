using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class CreatePartyValidator : AbstractValidator<PartyDto>
    {
        public CreatePartyValidator(VoterContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                .Must(n => !context.Partys.Any(party => party.Name == n))
                .WithMessage("There can not be two parties with the same name.");
        }
    }
}
