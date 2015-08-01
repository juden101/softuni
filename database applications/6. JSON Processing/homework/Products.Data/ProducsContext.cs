namespace Products.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data.Migrations;

    using Models;

    public class ProducsContext : DbContext
    {
        public ProducsContext()
            : base("name=ProducsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProducsContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsBought)
                .WithOptional(p => p.Buyer)
                .Map(m =>
                {
                    m.MapKey("BuyerId");
                });


            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsSold)
                .WithOptional(p => p.Seller)
                .Map(m =>
                {
                    m.MapKey("SallerId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}