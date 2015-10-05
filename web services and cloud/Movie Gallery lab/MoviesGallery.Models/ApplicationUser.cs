using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace MoviesGallery.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Movie> favouriteMovies;
        private ICollection<Actor> favouriteActors;
        private ICollection<Review> reviews;

        public ApplicationUser()
        {
            this.favouriteMovies = new HashSet<Movie>();
            this.favouriteActors = new HashSet<Actor>();
            this.reviews = new HashSet<Review>();
        }

        public string PersonalPage { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Movie> FavouriteMovies
        {
            get { return this.favouriteMovies; }
            set { this.favouriteMovies = value; }
        }

        public virtual ICollection<Actor> FavouriteActors
        {
            get { return this.favouriteActors; }
            set { this.favouriteActors = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<ApplicationUser> manager,
            string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(
                this, authenticationType);

            return userIdentity;
        }
    }
}