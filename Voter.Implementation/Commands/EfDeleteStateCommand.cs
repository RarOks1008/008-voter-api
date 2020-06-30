using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Commands;
using Voter.Application.Exceptions;
using Voter.Domain;
using Voter.EfDataAccess;

namespace Voter.Implementation.Commands
{
    public class EfDeleteStateCommand : IDeleteStateCommand
    {
        private readonly VoterContext _context;

        public EfDeleteStateCommand(VoterContext context)
        {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Delete State";

        public void Execute(int request)
        {
            var state = _context.States.Find(request);

            if (state == null)
            {
                throw new EntityNotFoundException(request, typeof(State));
            }

            _context.States.Remove(state);
            _context.SaveChanges();
        }
    }
}
