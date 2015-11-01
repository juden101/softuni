namespace Events.Data
{
    using Events.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using Events.Data.Migrations;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Events.Data.Migrations.DbConfiguration>());
        }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}