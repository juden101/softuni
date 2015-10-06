namespace MoviesGallery.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesGalleryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MoviesGalleryEntities context)
        {
            return;

            var user1 = new ApplicationUser()
            {
                Email = "ivan@gmail.com",
                UserName = "ivan",
                PasswordHash = new PasswordHasher().HashPassword("ivan"),
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                PersonalPage = "ivan.com"
            };

            var user2 = new ApplicationUser()
            {
                Email = "minka",
                UserName = "minka@email.co.uk",
                PasswordHash = new PasswordHasher().HashPassword("minka"),
                Gender = Gender.Female,
                BirthDate = DateTime.Now,
                PersonalPage = "minka_we"
            };

            var user3 = new ApplicationUser()
            {
                Email = "stamat",
                UserName = "stamat_li",
                PasswordHash = new PasswordHasher().HashPassword("stamatii"),
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                PersonalPage = "stamat.com"
            };

            var user4 = new ApplicationUser()
            {
                Email = "gergan",
                UserName = "gergan@gmail.com",
                PasswordHash = new PasswordHasher().HashPassword("gergan!"),
                Gender = Gender.Male,
                BirthDate = DateTime.Now,
                PersonalPage = "gergan.com"
            };

            var actor1 = new Actor()
            {
                Name = "Johny Depp",
                Biography = "Mnogo div",
                BornDate = DateTime.Now,
                HomeTown = "Kazanluk"
            };

            var actor2 = new Actor()
            {
                Name = "Asan Blatechki",
                Biography = "Obicham salam",
                BornDate = DateTime.Now,
                HomeTown = "Bacova Mahala"
            };

            var actor3 = new Actor()
            {
                Name = "Big Mamma",
                Biography = "da ide obi4a tia",
                BornDate = DateTime.Now,
                HomeTown = "Krun"
            };

            var actor4 = new Actor()
            {
                Name = "Dendy",
                Biography = "pulen gei",
                BornDate = DateTime.Now,
                HomeTown = "Pedalevo"
            };

            var genre1 = new Genre()
            {
                Name = "Gavri"
            };

            var genre2 = new Genre()
            {
                Name = "Parodii"

            };

            var genre3 = new Genre()
            {
                Name = "Porno s Akuli"

            };
            var genre4 = new Genre()
            {
                Name = "Liubimete na Alexandar Kamenov"

            };

            var review1 = new Review()
            {
                Content = "gangbang",
                DateOfCreation = DateTime.Now,
                User = user1
            };

            var review2 = new Review()
            {
                Content = "MnooTapWe",
                DateOfCreation = DateTime.Now,
                User = user3
            };

            var review3 = new Review()
            {
                Content = "BasiManqkaaa",
                DateOfCreation = DateTime.Now,
                User = user4
            };

            var review4 = new Review()
            {
                Content = "QkataDrama",
                DateOfCreation = DateTime.Now,
                User = user2
            };

            var movie1 = new Movie()
            {
                Title = "Babi po stalbite",
                Actors = new HashSet<Actor>
                {
                     actor1,
                     actor3
                },
                Country = "Tadzhekistan",
                Length = 50000000,
                Reviews = new HashSet<Review>
                {
                    review2,

                },
                Ration = 5,
                Genre = genre1
            };

            var movie2 = new Movie()
            {
                Title = "S Maikati Na More",
                Actors = new HashSet<Actor>
                {
                     actor4,
                     actor2
                },
                Country = "Tadzhekistan",
                Length = 2,
                Reviews = new HashSet<Review>
                {
                    review3,

                },
                Ration = 1,
                Genre = genre2
            };

            var movie3 = new Movie()
            {
                Title = "Shta Izpliushtq",
                Actors = new HashSet<Actor>
                {
                     actor1,
                },
                Country = "Turkmenistan",
                Length = 2213214,
                Reviews = new HashSet<Review>
                {
                    review1,

                },
                Ration = 10,
                Genre = genre3
            };
            var movie4 = new Movie()
            {
                Title = "E Sq Stana strashno 3",
                Actors = new HashSet<Actor>
                {
                     actor4,
                     
                },
                Country = "Buzlidja",
                Length = 69696969,
                Reviews = new HashSet<Review>
                {
                    review4,

                },
                Ration = 8,
                Genre = genre4
            };

            context.Movies.Add(movie1);
            context.Movies.Add(movie2);
            context.Movies.Add(movie3);
            context.Movies.Add(movie4);

            context.SaveChanges();

            user1.FavouriteMovies.Add(movie2);
            user1.FavouriteMovies.Add(movie3);

            user2.FavouriteMovies.Add(movie4);
            user2.FavouriteMovies.Add(movie1);

            user3.FavouriteMovies.Add(movie1);

            user4.FavouriteMovies.Add(movie3);
            user4.FavouriteMovies.Add(movie4);

            context.SaveChanges();

            user4.FavouriteActors.Add(actor3);
            user4.FavouriteActors.Add(actor4);
            user3.FavouriteActors.Add(actor1);
            user2.FavouriteActors.Add(actor4);
            user2.FavouriteActors.Add(actor1);
            user1.FavouriteActors.Add(actor2);
            user1.FavouriteActors.Add(actor3);

            context.SaveChanges();

            user4.Reviews.Add(review1);
            user3.Reviews.Add(review2);
            user2.Reviews.Add(review3);
            user1.Reviews.Add(review4);

            context.SaveChanges();
        }
    }
}