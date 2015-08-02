namespace Movies.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Movies.Models;
    using Newtonsoft.Json;

    using Data;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesEntities>
    {
        private MoviesEntities moviesContext;
        private DbSet<Country> allCountries;
        private DbSet<User> allUsers;
        private DbSet<Movie> allMovies;
        private DbSet<Rating> allRatings;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MoviesEntities moviesContext)
        {
            this.moviesContext = moviesContext;

            this.allCountries = moviesContext.Countries;
            this.allUsers = moviesContext.Users;
            this.allMovies = moviesContext.Movies;
            this.allRatings = moviesContext.Ratings;

            // import countries
            this.ImportCountries("../../../data/countries.json");
            
            //import users
            this.ImportUsers("../../../data/users.json");
            
            // import movies
            this.ImportMovies("../../../data/movies.json");
            
            // import users' favourite movies
            this.ImportUsersFavouriteMovies("../../../data/users-and-favourite-movies.json");

            // import movie ratings
            this.ImportMovieRatings("../../../data/movie-ratings.json");
        }

        private void ImportCountries(string inputLocation)
        {
            string jsonCountries = File.ReadAllText(inputLocation);
            var countries = JsonConvert.DeserializeObject<CountryDTO[]>(jsonCountries);

            foreach (var country in countries)
            {
                var newCountry = new Country()
                {
                    Name = country.Name
                };

                this.allCountries.AddOrUpdate(
                    c => c.Name,
                    newCountry
                );
            }

            this.moviesContext.SaveChanges();
        }

        private void ImportUsers(string inputLocation)
        {
            string jsonUsers = File.ReadAllText(inputLocation);
            var users = JsonConvert.DeserializeObject<UserDTO[]>(jsonUsers);

            foreach (var user in users)
            {
                var newUser = new User()
                {
                    Username = user.Username,
                    Age = user.Age,
                    Email = user.Email,
                    Country = this.allCountries.Where(c => c.Name == user.Country).FirstOrDefault()
                };

                moviesContext.Users.AddOrUpdate(
                    u => u.Username,
                    newUser
                );
            }

            moviesContext.SaveChanges();
        }

        private void ImportMovies(string inputLocation)
        {
            string jsonMovies = File.ReadAllText(inputLocation);
            var movies = JsonConvert.DeserializeObject<MovieDTO[]>(jsonMovies);

            foreach (var movie in movies)
            {
                var newMovie = new Movie()
                {
                    Isbn = movie.Isbn,
                    Title = movie.Title,
                    AgeRestriction = movie.AgeRestriction
                };

                moviesContext.Movies.AddOrUpdate(
                    m => m.Isbn,
                    newMovie
                );
            }

            moviesContext.SaveChanges();
        }

        private void ImportUsersFavouriteMovies(string inputLocation)
        {
            string jsonUsersFavouriteMovies = File.ReadAllText(inputLocation);
            var usersFavouriteMovies = JsonConvert.DeserializeObject<UsersAndFavouriteMoviesDTO[]>(jsonUsersFavouriteMovies);

            foreach (var userFavouriteMovies in usersFavouriteMovies)
            {
                var currentUser = this.allUsers.Where(u => u.Username == userFavouriteMovies.Username).FirstOrDefault();

                if (currentUser != null)
                {
                    foreach (var movieIsbn in userFavouriteMovies.FavouriteMovies)
                    {
                        var movie = this.allMovies.Where(m => m.Isbn == movieIsbn).FirstOrDefault();

                        if (!currentUser.Movies.Contains(movie))
                        {
                            currentUser.Movies.Add(movie);
                        }
                    }
                }
            }

            moviesContext.SaveChanges();
        }

        private void ImportMovieRatings(string inputLocation)
        {
            string jsonMovieRatings = File.ReadAllText(inputLocation);
            var movieRatings = JsonConvert.DeserializeObject<MovieRatingsDTO[]>(jsonMovieRatings);

            foreach (var movieRating in movieRatings)
            {
                var currentUser = this.allUsers.Where(u => u.Username == movieRating.User).FirstOrDefault();
                var currentMovie = this.allMovies.Where(m => m.Isbn == movieRating.Movie).FirstOrDefault();

                var newRating = new Rating()
                {
                    Movie = currentMovie,
                    User = currentUser,
                    Stars = movieRating.Rating
                };

                var dbRating = this.allRatings.Where(r => r.Movie.Id == currentMovie.Id && r.User.Id == currentUser.Id).FirstOrDefault();

                if (dbRating == null)
                {
                    moviesContext.Ratings.Add(newRating);
                }
            }

            moviesContext.SaveChanges();
        }
    }
}