﻿using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Application.Commands
{
    public interface IPersonVoteCommand : ICommand<PersonVoteDto>
    {
    }
}
