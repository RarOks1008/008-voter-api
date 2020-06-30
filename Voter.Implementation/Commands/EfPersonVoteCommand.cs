using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.EfDataAccess;
using Voter.Implementation.Validators;

namespace Voter.Implementation.Commands
{
    public class EfPersonVoteCommand : IPersonVoteCommand
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;
        private readonly PersonVoteValidator _validator;

        public EfPersonVoteCommand(VoterContext context, IApplicationActor actor, PersonVoteValidator validator)
        {
            _context = context;
            _actor = actor;
            _validator = validator;
        }

        public int Id => 24;

        public string Name => "Person Vote";

        public void Execute(PersonVoteDto request)
        {
            if (request.OptionId != null)
            {
                _validator.ValidateAndThrow(request);
            }
            var person = _context.Persons.Find(_actor.Id);
            person.OptionId = request.OptionId;
            _context.SaveChanges();
        }
    }
}
