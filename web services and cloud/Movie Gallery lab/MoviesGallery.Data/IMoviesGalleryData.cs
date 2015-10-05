using MoviesGallery.Data.Repositories;
using MoviesGallery.Models;

namespace MoviesGallery.Data
{
    public interface IMoviesGalleryData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Movie> Movies { get; }

        IRepository<Genre> Genres { get; }

        IRepository<Actor> Actors { get; }

        IRepository<Review> Reviews { get; }

        int SaveChanges();
    }
}
