﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Application.DataTransfer
{
    public class LogDto
    {
        public DateTime Date { get; set; }
        public string Actor { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
    }
}
