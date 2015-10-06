namespace MoviesGallery.WebServices.Models
{
    using MoviesGallery.Models;

    public class ShortActorDataViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static ShortActorDataViewModel Create(Actor actor)
        {
            return new ShortActorDataViewModel()
            {
                Id = actor.Id,
                Name = actor.Name
            };
        }
    }
}