namespace News.Services.Models.ViewModels
{
    using System;

    public class ShortNewsDataViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public static ShortNewsDataViewModel Create(News.Models.News news)
        {
            return new ShortNewsDataViewModel()
            {
                Id = news.Id,
                Title = news.Title,
                PublishDate = news.PublishDate
            };
        }
    }
}