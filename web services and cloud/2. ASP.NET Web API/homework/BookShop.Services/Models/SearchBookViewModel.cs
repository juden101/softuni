namespace BookShop.Services.Models
{
    using BookShop.Models;
    using System;
    using System.Linq.Expressions;

    public class SearchBookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public static Expression<Func<Book, SearchBookViewModel>> Create
        {
            get
            {
                return b => new SearchBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title
                };
            }
        }
    }
}