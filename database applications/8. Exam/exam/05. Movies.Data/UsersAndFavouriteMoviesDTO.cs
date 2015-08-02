namespace Movies.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersAndFavouriteMoviesDTO
    {
        public string Username { get; set; }

        public virtual string[] FavouriteMovies { get; set; }
    }
}