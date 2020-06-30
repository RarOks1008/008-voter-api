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
    public class EfUpdateStateCommand : IUpdateStateCommand
    {
        private readonly VoterContext _context;
        private readonly UpdateStateValidator _validator;

        public EfUpdateStateCommand(VoterContext context, UpdateStateValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 20;

        public string Name => "Update State";

        public void Execute(StateDto request)
        {
            _validator.ValidateAndThrow(request);
            var state = _context.States.Find(request.Id);
            if (state == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(State));
            }
            state.Name = request.Name;
            _context.SaveChanges();
        }
    }
}
