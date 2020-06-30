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
            CreateMap<Domain.Option, OptionDto>();
        }
    }
}
