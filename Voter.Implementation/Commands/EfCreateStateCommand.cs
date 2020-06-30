using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.Commands;
using Voter.Application.DataTransfer;
using Voter.Domain;
using Voter.EfDataAccess;
using Voter.Implementation.Validators;

namespace Voter.Implementation.Commands
{
    public class EfCreateStateCommand : ICreateStateCommand
    {
        private readonly VoterContext _context;
        private readonly CreateStateValidator _validator;

        public EfCreateStateCommand(VoterContext context, CreateStateValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create New State";

        public void Execute(StateDto request)
        {
            _validator.ValidateAndThrow(request);

            var state = new State
            {
                Name = request.Name
            };

            _context.States.Add(state);
            _context.SaveChanges();
        }
    }
}
