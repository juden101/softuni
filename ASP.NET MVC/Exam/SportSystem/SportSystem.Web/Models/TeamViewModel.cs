using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSystem.Web.Models
{
    public class TeamViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public int VotesCount { get; set; }
    }
}