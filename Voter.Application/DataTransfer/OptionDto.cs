﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Application.DataTransfer
{
    public class OptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int StateId { get; set; }
        public int? PartyId { get; set; }
        public string PartyName { get; set; }
        public string StateName { get; set; }
    }
}
