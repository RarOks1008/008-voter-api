using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Application.Exceptions
{
    public class NotAllowedToViewOrEditException : Exception
    {
        public NotAllowedToViewOrEditException() : base("You are only allowed to view and edit data in your country.")
        {
        }
    }
}
