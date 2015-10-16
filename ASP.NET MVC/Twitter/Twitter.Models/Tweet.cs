namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<ApplicationUser> favouritedBy;
        private ICollection<ApplicationUser> retweetedBy;

        public Tweet()
        {
            this.favouritedBy = new HashSet<ApplicationUser>();
            this.retweetedBy = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }
    }
}