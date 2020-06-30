using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;

namespace Voter.Implementation.Validators
{
    public class UpdateRegionValidator : AbstractValidator<RegionDto>
    {
        public UpdateRegionValidator(VoterContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                .Must((dto, n) => !context.Regions.Any(region => region.Name == n && region.Id != dto.Id))
                .WithMessage("There can not be two regions with the same name.");
            RuleFor(x => x.StateId).NotEmpty()
                .Must(id => context.States.Any(s => s.Id == id))
                .WithMessage("State must exist");
        }
    }
}
