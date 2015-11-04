namespace SportSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        [Key]
        public int Id { get; set; }

        public string BettingUserId { get; set; }

        [Required]
        public virtual ApplicationUser BettingUser { get; set; }

        public virtual Match Match { get; set; }

        public decimal? HomeBet { get; set; }

        public decimal? AwayBet { get; set; }
    }
}