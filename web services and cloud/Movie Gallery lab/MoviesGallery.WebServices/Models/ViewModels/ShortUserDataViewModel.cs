namespace MoviesGallery.WebServices.Models
{
    using MoviesGallery.Models;
    using System;

    public class ShortUserDataViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public DateTime BirthDate { get; set; }

        public string PersonalPage { get; set; }

        public static ShortUserDataViewModel Create(ApplicationUser user)
        {
            return new ShortUserDataViewModel()
            {
                Id = user.Id,
                Username = user.UserName,
                BirthDate = user.BirthDate,
                PersonalPage = user.PersonalPage
            };
        }
    }
}