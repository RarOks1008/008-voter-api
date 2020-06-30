using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class UpdatePersonValidator : AbstractValidator<PersonDto>
    {
        public UpdatePersonValidator(VoterContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.PersonalId).NotEmpty()
                .MinimumLength(13)
                .MaximumLength(13)
                .Must((dto, p) => !context.Persons.Any(user => user.PersonalId == p && user.Id != dto.Id))
                .WithMessage("There can not be two people with same Personal Identification");
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.RegionId).NotEmpty()
                .Must(id => context.Regions.Any(x => (x.Id == id)))
                .WithMessage("Region must exist");
        }
    }
}
