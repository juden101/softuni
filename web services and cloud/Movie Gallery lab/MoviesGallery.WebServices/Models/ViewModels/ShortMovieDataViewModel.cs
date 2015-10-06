namespace MoviesGallery.WebServices.Models
{
    using MoviesGallery.Models;

    public class ShortMovieDataViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public static ShortMovieDataViewModel Create(Movie movie)
        {
            return new ShortMovieDataViewModel()
            {
                Id = movie.Id,
                Title = movie.Title
            };
        }
    }
}