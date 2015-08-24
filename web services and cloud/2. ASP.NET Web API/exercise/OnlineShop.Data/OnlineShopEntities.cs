namespace OnlineShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;

    public class OnlineShopEntities : IdentityDbContext<ApplicationUser>
    {
        public OnlineShopEntities()
            : base("OnlineShopEntities")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<OnlineShopEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual DbSet<Ad> Ads { get; set; }

        public virtual DbSet<AdType> AdTypes { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public static OnlineShopEntities Create()
        {
            return new OnlineShopEntities();
        }
    }
}