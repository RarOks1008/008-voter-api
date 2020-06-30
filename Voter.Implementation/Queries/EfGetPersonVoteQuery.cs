using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application;
using Voter.Application.DataTransfer;
using Voter.Application.Exceptions;
using Voter.Application.Queries;
using Voter.EfDataAccess;

namespace Voter.Implementation.Queries
{
    public class EfGetPersonVoteQuery : IGetPersonVoteQuery
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;

        public EfGetPersonVoteQuery(VoterContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 27;

        public string Name => "Get My Vote";

        public PersonVoteDto Execute(object search)
        {
            var person = _context.Persons.Find(_actor.Id);
            return new PersonVoteDto
            {
                OptionId = person.OptionId
            };
        }
    }
}
