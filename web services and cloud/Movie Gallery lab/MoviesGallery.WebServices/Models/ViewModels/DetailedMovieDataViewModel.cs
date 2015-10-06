namespace MoviesGallery.WebServices.Models
{
    using MoviesGallery.Models;

    public class DetailedMovieDataViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Length { get; set; }

        public int Ration { get; set; }

        public string Country { get; set; }

        public string Genre { get; set; }

        public static DetailedMovieDataViewModel Create(Movie movie)
        {
            return new DetailedMovieDataViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Length = movie.Length,
                Ration = movie.Ration,
                Country = movie.Country,
                Genre = movie.Genre.Name
            };
        }
    }
}