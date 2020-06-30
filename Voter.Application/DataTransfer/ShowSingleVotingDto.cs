using System;
using System.Collections.Generic;
using System.Text;

namespace Voter.Application.DataTransfer
{
    public class ShowSingleVotingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int RegionId { get; set; }
        public int CountNumber { get; set; }
    }
}
