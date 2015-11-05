using SportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSystem.Web.Models
{
    public class DetailedMatchViewModel
    {
        public int Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public DateTime DateAndTime { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}