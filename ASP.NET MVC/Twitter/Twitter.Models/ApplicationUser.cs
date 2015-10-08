using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Message> messages;
        private ICollection<Tweet> tweets;
        private ICollection<ApplicationUser> followers;
        private ICollection<ApplicationUser> following;
        private ICollection<Tweet> favouriteTweets;

        public ApplicationUser()
        {
            this.messages = new HashSet<Message>();
            this.tweets = new HashSet<Tweet>();
            this.followers = new HashSet<ApplicationUser>();
            this.following = new HashSet<ApplicationUser>();
            this.favouriteTweets = new HashSet<Tweet>();
        }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }

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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<ApplicationUser> manager,
            string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
