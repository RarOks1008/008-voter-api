using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.Application.Exceptions;
using Voter.Domain;
using Voter.EfDataAccess;
using Voter.Implementation.Validators;

namespace Voter.Implementation.Commands
{
    public class EfUpdatePartyCommand : IUpdatePartyCommand
    {
        private readonly VoterContext _context;
        private readonly UpdatePartyValidator _validator;

        public EfUpdatePartyCommand(VoterContext context, UpdatePartyValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 31;

        public string Name => "Update Party";

        public void Execute(PartyDto request)
        {
            _validator.ValidateAndThrow(request);
            var party = _context.Partys.Find(request.Id);
            if (party == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Party));
            }
            party.Name = request.Name;
            _context.SaveChanges();
        }
    }
}
