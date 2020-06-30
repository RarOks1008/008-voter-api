using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, Type type)
            : base($"Entity type {type.Name} with id {id} was not found.")
        {
        }
    }
}
