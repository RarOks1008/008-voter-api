using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voter.Application;
using Voter.Application.DataTransfer;
using Voter.Application.Exceptions;
using Voter.Application.Queries;
using Voter.Domain;
using Voter.EfDataAccess;

namespace Voter.Implementation.Queries
{
    public class EfGetPersonQuery : IGetPersonQuery
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfGetPersonQuery(VoterContext context, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Get Person";

        public PersonDto Execute(int search)
        {
            var person = _context.Persons.Include(x => x.Region).FirstOrDefault(x => x.Id == search);
            if (person == null)
            {
                throw new EntityNotFoundException(search, typeof(Person));
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);
            var personObj = _context.Persons.Find(person.Id);
            var personRegion = _context.Regions.Find(personObj.RegionId);
            if (actorRegion.StateId != personRegion.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }

            return _mapper.Map<PersonDto>(person);
        }
    }
}
