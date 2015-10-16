namespace Twitter.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class TwitterDbContext : IdentityDbContext<ApplicationUser>
    {
        public TwitterDbContext()
            : base("TwitterDbContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
        }

        public IDbSet<Tweet> Tweets { get; set; }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }
    }
}