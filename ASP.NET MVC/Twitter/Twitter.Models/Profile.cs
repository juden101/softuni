namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Profile
    {
        private ICollection<ApplicationUser> followers;
        private ICollection<ApplicationUser> following;
        private ICollection<Tweet> favouriteTweets;

        public Profile()
        {
            this.followers = new HashSet<ApplicationUser>();
            this.following = new HashSet<ApplicationUser>();
            this.favouriteTweets = new HashSet<Tweet>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<ApplicationUser> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<ApplicationUser> Following
        {
            get { return this.following; }
            set { this.following = value; }
        }

        public virtual ICollection<Tweet> FavouriteTweets
        {
            get { return this.favouriteTweets; }
            set { this.favouriteTweets = value; }
        }
    }
}