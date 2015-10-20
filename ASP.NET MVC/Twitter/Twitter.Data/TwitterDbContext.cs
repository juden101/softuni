namespace Twitter.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class TwitterDbContext : IdentityDbContext<ApplicationUser>
    {
        public TwitterDbContext()
            : base("TwitterDbContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }
        public virtual IDbSet<Notification> Notifications { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
               .Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.FollowersUsers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowerId");
                    m.ToTable("UserFollowers");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.FollowingUsers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowedId");
                    m.ToTable("FolloedUsers");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReceivedMessages)
                .WithRequired(u => u.Sender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReceivedNotifications)
                .WithRequired(u => u.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .HasRequired(t => t.Author)
                .WithMany(a => a.OwnTweets)
                .HasForeignKey(t => t.AuthorId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.OwnTweets);

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.Likes)
                .WithMany(t => t.FavouriteTweets)
                .Map(m =>
                {
                    m.MapLeftKey("TweetId");
                    m.MapRightKey("UserId");
                    m.ToTable("FavouriteTweets");
                });

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.Retweets)
                .WithMany(t => t.Retweets)
                .Map(t =>
                {
                    t.MapLeftKey("TweetId");
                    t.MapRightKey("UserId");
                    t.ToTable("Retweets");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}