using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Application.Email
{
    public interface IEmailSender
    {
        void Send(MailDto dto);
    }
}
