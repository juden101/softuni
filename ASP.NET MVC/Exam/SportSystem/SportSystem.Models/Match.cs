namespace SportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Match
    {
        public Match()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public DateTime DateAndTime { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}