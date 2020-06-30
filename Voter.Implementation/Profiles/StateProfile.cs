using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Implementation.Profiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<Domain.State, StateDto>();
        }
    }
}
