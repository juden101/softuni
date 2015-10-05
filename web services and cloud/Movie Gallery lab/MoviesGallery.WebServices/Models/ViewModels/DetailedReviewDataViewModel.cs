namespace MoviesGallery.WebServices.Models
{
    using MoviesGallery.Models;

    public class DetailedReviewDataViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ShortMovieDataViewModel Movie { get; set; }

        public ShortUserDataViewModel User { get; set; }

        public static DetailedReviewDataViewModel Create(Review review)
        {
            return new DetailedReviewDataViewModel()
            {
                Id = review.Id,
                Content = review.Content,
                Movie = ShortMovieDataViewModel.Create(review.Movie),
                User = ShortUserDataViewModel.Create(review.User)
            };
        }
    }
}