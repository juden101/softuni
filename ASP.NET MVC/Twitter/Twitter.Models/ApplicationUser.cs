﻿using Microsoft.AspNet.Identity;
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
        private ICollection<Tweet> ownTweets;
        private ICollection<Tweet> favouriteTweets;
        private ICollection<Tweet> retweets;
        private ICollection<ApplicationUser> followersUsers;
        private ICollection<ApplicationUser> followingUsers;
        private ICollection<Message> sentMessages;
        private ICollection<Message> receivedMessages;
        private ICollection<Notification> receivedNotifications;
        private ICollection<Notification> involvedNotifications;

        public ApplicationUser()
        {
            this.ownTweets = new HashSet<Tweet>();
            this.favouriteTweets = new HashSet<Tweet>();
            this.retweets = new HashSet<Tweet>();
            this.followersUsers = new HashSet<ApplicationUser>();
            this.followingUsers = new HashSet<ApplicationUser>();
            this.sentMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            this.receivedNotifications = new HashSet<Notification>();
            this.involvedNotifications = new HashSet<Notification>();
        }

        public string AvatarUrl { get; set; }

        public string FullName { get; set; }

        public string Biography { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }

        public DateTime? BirthDay { get; set; }

        public virtual ICollection<Tweet> OwnTweets
        {
            get { return this.ownTweets; }
            set { this.ownTweets = value; }
        }

        public virtual ICollection<Tweet> FavouriteTweets
        {
            get { return this.favouriteTweets; }
            set { this.favouriteTweets = value; }
        }

        public virtual ICollection<Tweet> Retweets
        {
            get { return this.retweets; }
            set { this.retweets = value; }
        }

        public virtual ICollection<ApplicationUser> FollowersUsers
        {
            get { return this.followersUsers; }
            set { this.followersUsers = value; }
        }

        public virtual ICollection<ApplicationUser> FollowingUsers
        {
            get { return this.followingUsers; }
            set { this.followingUsers = value; }
        }

        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }

        public virtual ICollection<Notification> ReceivedNotifications
        {
            get { return this.receivedNotifications; }
            set { this.receivedNotifications = value; }
        }

        public virtual ICollection<Notification> InvolvedNotifications
        {
            get { return this.involvedNotifications; }
            set { this.involvedNotifications = value; }
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
