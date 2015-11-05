using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSystem.Web.Models
{
    public class MatchViewModel
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public DateTime DateAndTime { get; set; }
    }
}