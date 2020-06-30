using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Implementation.Validators
{
    public class SendMailValidator : AbstractValidator<MailDto>
    {
        public SendMailValidator()
        {
            RuleFor(x => x.From).NotEmpty().EmailAddress();
            RuleFor(x => x.Subject).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
