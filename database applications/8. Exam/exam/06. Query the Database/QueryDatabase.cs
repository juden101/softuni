namespace QueryDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Movies.Models;
    using Movies.Data;
    using Newtonsoft.Json;
    using System.IO;

    public class QueryDatabase
    {
        private static MoviesEntities moviesContext;

        public static void Main()
        {
            moviesContext = new MoviesEntities();

            ExportAdultMovies();
            ExportRatedMovieByUser("jmeyery");
            ExportTopTenFavouriteFilms();
        }

        private static void ExportAdultMovies()
        {
            var adultMovies = moviesContext.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Adult)
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Ratings.Count)
                .Select(m => new
                {
                    title = m.Title,
                    ratingGiven = m.Ratings.Count()
                });

            var adultMoviesJson = JsonConvert.SerializeObject(adultMovies, Formatting.Indented);

            File.WriteAllText("../../adult-movies.json", adultMoviesJson);
        }

        private static void ExportRatedMovieByUser(string username)
        {
            var ratedMovies = moviesContext.Users
                .Where(u => u.Username == username)
                .Select(u => new
                {
                    username = u.Username,
                    ratedMovies = u.Ratings
                        .OrderBy(r => r.Movie.Title)
                        .Select(r => new
                        {
                            title = r.Movie.Title,
                            userRating = r.Stars,
                            averageRating = r.Movie.Ratings.Average(rr => rr.Stars)
                        })
                });

            var ratedMoviesJson = JsonConvert.SerializeObject(ratedMovies, Formatting.Indented);

            File.WriteAllText("../../rated-movies-by-jmeyery.json", ratedMoviesJson);
        }

        private static void ExportTopTenFavouriteFilms()
        {
            var favouriteMovies = moviesContext.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Teen)
                .OrderByDescending(m => m.Users.Count)
                .ThenBy(m => m.Title)
                .Select(m => new
                {
                    isbn = m.Isbn,
                    title = m.Title,
                    favouritedBy = m.Users.Select(u => u.Username)
                })
                .Take(10);

            var favouriteMoviesJson = JsonConvert.SerializeObject(favouriteMovies, Formatting.Indented);

            File.WriteAllText("../../top-10-favourite-movies.json", favouriteMoviesJson);
        }
    }
}