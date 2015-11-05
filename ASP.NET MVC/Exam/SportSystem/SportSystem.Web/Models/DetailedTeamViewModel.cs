using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSystem.Web.Models
{
    public class DetailedTeamViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public DateTime DateFounded { get; set; }

        public int VotesCount { get; set; }

        public bool UserHasVoted { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }
    }
}