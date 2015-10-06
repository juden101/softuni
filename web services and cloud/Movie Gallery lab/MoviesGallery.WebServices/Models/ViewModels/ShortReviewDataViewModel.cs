namespace MoviesGallery.WebServices.Models
{
    using MoviesGallery.Models;

    public class ShortReviewDataViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public static ShortReviewDataViewModel Create(Review review)
        {
            return new ShortReviewDataViewModel()
            {
                Id = review.Id,
                Content = review.Content
            };
        }
    }
}