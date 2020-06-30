using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.Application.Email;
using Voter.Implementation.Validators;

namespace Voter.Implementation.Commands
{
    public class EfSendMailCommand : ISendMailCommand
    {
        private readonly SendMailValidator _validator;
        private readonly IEmailSender _sender;

        public EfSendMailCommand(SendMailValidator validator, IEmailSender sender)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id => 5;

        public string Name => "Send Mail";

        public void Execute(MailDto request)
        {
            _validator.ValidateAndThrow(request);

            _sender.Send(request);
        }
    }
}
