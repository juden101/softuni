namespace News.Services.Models.ViewModels
{
    using System;

    public class DetailedNewsDataViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public static DetailedNewsDataViewModel Create(News.Models.News news)
        {
            return new DetailedNewsDataViewModel()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                PublishDate = news.PublishDate
            };
        }
    }
}