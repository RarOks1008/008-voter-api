﻿using System;
using System.Collections.Generic;
using System.Text;
using Voter.Application.DataTransfer;

namespace Voter.Application.Queries
{
    public interface IGetOptionQuery : IQuery<int, OptionDto>
    {
    }
}
