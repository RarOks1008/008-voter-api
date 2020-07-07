using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Implementation.Profiles
{
    public class OptionProfile : Profile
    {
        public OptionProfile()
        {
            CreateMap<Domain.Option, OptionDto>()
                .ForMember(dest => dest.PartyName, opt => opt.MapFrom(x => x.Party.Name))
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(x => x.State.Name));
        }
    }
}
