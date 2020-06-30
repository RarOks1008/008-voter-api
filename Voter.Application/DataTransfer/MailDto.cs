using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Application.DataTransfer
{
    public class MailDto
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
