namespace BookShopSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Models;
    using Data.Migrations;

    public class BookShopContext : DbContext
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("BookId");
                    m.MapRightKey("RelatedBookId");
                    m.ToTable("RelatedBooks");
                });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}