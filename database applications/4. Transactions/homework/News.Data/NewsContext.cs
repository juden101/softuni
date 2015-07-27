namespace News.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Models;
    using Data.Migrations;

    public class NewsContext : DbContext
    {
        public NewsContext()
            : base("name=NewsContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<NewsContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<News> News { get; set; }
    }
}