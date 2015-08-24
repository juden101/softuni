namespace BookShop.Services.Models
{
    using BookShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class AuthorViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<BookTitleViewModel> BookTitles { get; set; }

        public static Expression<Func<Author, AuthorViewModel>> Create
        {
            get
            {
                return a => new AuthorViewModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BookTitles = a.Books
                        .Select(b => new BookTitleViewModel()
                        {
                            Title = b.Title
                        })
                };
            }
        }
    }
}