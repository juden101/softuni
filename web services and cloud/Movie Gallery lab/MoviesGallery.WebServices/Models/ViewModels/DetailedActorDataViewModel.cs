namespace MoviesGallery.WebServices.Models
{
    using MoviesGallery.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DetailedActorDataViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BornDate { get; set; }

        public string Biography { get; set; }

        public string HomeTown { get; set; }

        public IEnumerable<ShortMovieDataViewModel> Movies { get; set; }

        public static DetailedActorDataViewModel Create(Actor actor)
        {
            return new DetailedActorDataViewModel()
            {
                Id = actor.Id,
                Name = actor.Name,
                BornDate = actor.BornDate,
                Biography = actor.Biography,
                HomeTown = actor.HomeTown,
                Movies = actor.Movies.Select(m => ShortMovieDataViewModel.Create(m))
            };
        }
    }
}