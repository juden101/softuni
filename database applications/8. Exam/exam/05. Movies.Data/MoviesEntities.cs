namespace Movies.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Models;
    using Migrations;
    using Newtonsoft.Json;

    public class MoviesEntities : DbContext
    {
        public MoviesEntities()
            : base("MoviesEntities")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<MoviesEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Movie>(u => u.Movies)
                .WithMany(m => m.Users)
                .Map(um =>
                {
                    um.MapLeftKey("UserId");
                    um.MapRightKey("MovieId");
                    um.ToTable("MovieUsers");
                });
        }*/
    }
}