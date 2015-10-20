namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet
    {
        private ICollection<ApplicationUser> likes;
        private ICollection<ApplicationUser> retweets;

        public Tweet()
        {
            this.likes = new HashSet<ApplicationUser>();
            this.retweets = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<ApplicationUser> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<ApplicationUser> Retweets
        {
            get { return this.retweets; }
            set { this.retweets = value; }
        }
    }
}