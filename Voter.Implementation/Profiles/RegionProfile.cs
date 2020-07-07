using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Implementation.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Domain.Region, RegionDto>()
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(x => x.State.Name));
        }
    }
}
