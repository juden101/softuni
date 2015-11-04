namespace SportSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Team Team { get; set; }

        public string UserId { get; set; }

        [Required]
        public virtual ApplicationUser VotingUser { get; set; }
    }
}