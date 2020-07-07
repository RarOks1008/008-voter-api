using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Commands;
using Voter.Application.Exceptions;
using Voter.Domain;
using Voter.EfDataAccess;

namespace Voter.Implementation.Commands
{
    public class EfDeletePartyCommand : IDeletePartyCommand
    {
        private readonly VoterContext _context;

        public EfDeletePartyCommand(VoterContext context)
        {
            _context = context;
        }

        public int Id => 32;

        public string Name => "Delete Party";

        public void Execute(int request)
        {
            var party = _context.Partys.Find(request);
            if (party == null)
            {
                throw new EntityNotFoundException(request, typeof(Party));
            }
            _context.Partys.Remove(party);
            _context.SaveChanges();
        }
    }
}
