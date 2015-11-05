using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSystem.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<TeamViewModel> BestTeams { get; set; }

        public IEnumerable<MatchViewModel> BestMatches { get; set; }
    }
}