namespace Movies.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Data;
    using System.IO;
    using Newtonsoft.Json;

    class MoviesConsoleClient
    {
        static void Main()
        {
            var moviesContext = new MoviesEntities();

            Console.WriteLine("Countries: {0}", moviesContext.Countries.Count());
            Console.WriteLine("Users: {0}", moviesContext.Users.Count());
            Console.WriteLine("Ratings: {0}", moviesContext.Ratings.Count());
            Console.WriteLine("Movies: {0}", moviesContext.Movies.Count());
        }
    }
}