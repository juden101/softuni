namespace Twitter.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class TwitterDbContext : IdentityDbContext<ApplicationUser>, ITwitterDbContext
    {
        public TwitterDbContext()
            : base("TwitterDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
        }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<Tweet> Tweets { get; set; }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Messages)
                .WithOptional();

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Author)
                .WithOptional();

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Receiver)
                .WithOptional();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.Followers)
                .WithOptional();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.Following)
                .WithOptional();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(au => au.FavouriteTweets)
                .WithOptional();

            modelBuilder.Entity<Tweet>()
                .HasRequired(t => t.Author)
                .WithOptional();

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.FavouritedBy)
                .WithOptional();

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.RetweetedBy)
                .WithOptional();
        }
    }
}