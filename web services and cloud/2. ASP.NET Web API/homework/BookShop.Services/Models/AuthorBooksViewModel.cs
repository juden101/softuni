namespace BookShop.Services.Models
{
    using BookShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class AuthorBooksViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BookType Type { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }
        
        public BookAgeRestriction AgeRestriction { get; set; }

        public IEnumerable<CategoryNamesViewModel> Categories { get; set; }

        public static Expression<Func<Book, AuthorBooksViewModel>> Create
        {
            get
            {
                return b => new AuthorBooksViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Type = b.Type,
                    Price = b.Price,
                    Copies = b.Copies,
                    ReleaseDate = b.ReleaseDate,
                    AgeRestriction = b.AgeRestriction,
                    Categories = b.Categories
                        .Select(c => new CategoryNamesViewModel()
                        {
                            Name = c.Name
                        })
                };
            }
        }
    }
}