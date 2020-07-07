using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;
using Voter.Implementation.Validators;

namespace Voter.Implementation.Commands
{
    public class EfCreatePartyCommand : ICreatePartyCommand
    {
        private readonly VoterContext _context;
        private readonly CreatePartyValidator _validator;

        public EfCreatePartyCommand(VoterContext context, CreatePartyValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Create Party";

        public void Execute(PartyDto request)
        {
            _validator.ValidateAndThrow(request);
            _context.Partys.Add(new Domain.Party
            {
                Name = request.Name
            });
            _context.SaveChanges();
        }
    }
}
