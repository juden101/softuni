namespace BookShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Models;
    using Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BookShopContext : IdentityDbContext<ApplicationUser>
    {
        public BookShopContext()
            : base("BookShopContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Category { get; set; }

        public IDbSet<Author> Author { get; set; }

        public IDbSet<Purchaise> Purchaises { get; set; }

        public static BookShopContext Create()
        {
            return new BookShopContext();
        }
    }
}