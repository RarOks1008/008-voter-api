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
    public class EfGetOptionQuery : IGetOptionQuery
    {
        private readonly VoterContext _context;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfGetOptionQuery(VoterContext context, IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 17;

        public string Name => "Get Option";

        public OptionDto Execute(int search)
        {
            var option = _context.Options.Include(x => x.Party).Include(s => s.State).FirstOrDefault(x => x.Id == search);
            if (option == null)
            {
                throw new EntityNotFoundException(search, typeof(Option));
            }

            var actorObj = _context.Persons.Find(_actor.Id);
            var actorRegion = _context.Regions.Find(actorObj.RegionId);

            if (actorRegion.StateId != option.StateId)
            {
                throw new NotAllowedToViewOrEditException();
            }

            return _mapper.Map<OptionDto>(option);
        }
    }
}
