using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Implementation.Profiles
{
    public class PartyProfile : Profile
    {
        public PartyProfile()
        {
            CreateMap<Domain.Party, PartyDto>();
        }
    }
}
