using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using MoviesGallery.Data.Repositories;
using MoviesGallery.Models;

namespace MoviesGallery.Data
{
    public class MoviesGalleryData : IMoviesGalleryData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public MoviesGalleryData()
            : this(new MoviesGalleryEntities())
        {
        }

        public MoviesGalleryData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Movie> Movies
        {
            get { return this.GetRepository<Movie>(); }
        }

        public IRepository<Genre> Genres
        {
            get { return this.GetRepository<Genre>(); }
        }

        public IRepository<Actor> Actors
        {
            get { return this.GetRepository<Actor>(); }
        }

        public IRepository<Review> Reviews
        {
            get { return this.GetRepository<Review>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof (T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof (GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}