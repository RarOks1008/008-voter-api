using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Implementation.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Domain.Person, PersonDto>()
                .ForMember(x => x.Password, opt => opt.Ignore())
                .ForMember(x => x.RoleId, opt => opt.Ignore())
                .ForMember(dest => dest.RegionName, opt => opt.MapFrom(x => x.Region.Name));
        }
    }
}
