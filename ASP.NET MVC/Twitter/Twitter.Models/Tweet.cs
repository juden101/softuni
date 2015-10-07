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
        [MinLength(3)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Reported { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public virtual ICollection<ApplicationUser> FavouritedBy
        {
            get { return this.favouritedBy; }
            set { this.favouritedBy = value; }
        }

        public virtual ICollection<ApplicationUser> RetweetedBy
        {
            get { return this.retweetedBy; }
            set { this.retweetedBy = value; }
        }
    }
}