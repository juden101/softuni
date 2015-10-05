namespace MoviesGallery.WebServices.Models
{
    using MoviesGallery.Models;

    public class DetailedGenreDataViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static DetailedGenreDataViewModel Create(Genre genre)
        {
            return new DetailedGenreDataViewModel()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}