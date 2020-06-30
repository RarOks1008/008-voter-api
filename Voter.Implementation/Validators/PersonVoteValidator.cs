using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class PersonVoteValidator : AbstractValidator<PersonVoteDto>
    {
        public PersonVoteValidator(VoterContext context, IApplicationActor actor)
        {
            RuleFor(x => x.OptionId)
                .Must(n => context.Options.Find(n).StateId == context.Regions.Find(context.Persons.Find(actor.Id).RegionId).StateId)
                .WithMessage("You can only vote in your own country");
        }
    }
}
