using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Application.Exceptions
{
    public class PersonIsAdminException : Exception
    {
        public PersonIsAdminException(int id)
            : base($"Person with an id {id} is admin and can not be deleted.")
        {
        }
    }
}
