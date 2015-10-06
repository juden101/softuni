namespace MoviesGallery.WebServices.Models
{
    using MoviesGallery.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DetailedUserDataViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public DateTime BirthDate { get; set; }

        public string PersonalPage { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public IEnumerable<ShortMovieDataViewModel> FavouriteMovies { get; set; }

        public IEnumerable<ShortActorDataViewModel> FavouriteActors { get; set; }

        public IEnumerable<ShortReviewDataViewModel> Reviews { get; set; }

        public static DetailedUserDataViewModel Create(ApplicationUser user)
        {
            return new DetailedUserDataViewModel()
            {
                Id = user.Id,
                Username = user.UserName,
                BirthDate = user.BirthDate,
                PersonalPage = user.PersonalPage,
                Email = user.Email,
                Gender = user.Gender,
                FavouriteMovies = user.FavouriteMovies
                    .Select(fm => ShortMovieDataViewModel.Create(fm)),
                FavouriteActors = user.FavouriteActors
                    .Select(fa => ShortActorDataViewModel.Create(fa)),
                Reviews = user.Reviews
                    .Select(r => ShortReviewDataViewModel.Create(r))
            };
        }
    }
}