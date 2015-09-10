namespace News.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using News.Models;
    using Migrations;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class NewsEntities : IdentityDbContext<ApplicationUser>
    {
        public NewsEntities()
            : base("NewsEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsEntities, Configuration>());
        }

        public virtual IDbSet<News> News { get; set; }

        public static NewsEntities Create()
        {
            return new NewsEntities();
        }
    }
}