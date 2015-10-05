namespace MoviesGallery.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MoviesGalleryEntities : IdentityDbContext<ApplicationUser>
    {
        public MoviesGalleryEntities()
            : base("MoviesGalleryEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesGalleryEntities, Configuration>());
        }

        public virtual DbSet<Actor> Actors { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public static MoviesGalleryEntities Create()
        {
            return new MoviesGalleryEntities();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(m => m.Movies)
                .Map(m =>
                {
                    m.MapLeftKey("MovieId");
                    m.MapRightKey("ActorId");
                    m.ToTable("MovieActors");
                });

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("MovieId");
                    m.MapRightKey("ReviewId");
                    m.ToTable("MovieReviews");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.FavouriteMovies)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("MovieId");
                    m.ToTable("UsersFavouriteMovies");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.FavouriteActors)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("ActorId");
                    m.ToTable("UsersFavouriteActors");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Reviews)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("ReviewId");
                    m.ToTable("UsersReviews");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}