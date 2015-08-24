namespace BookShop.Services.Models
{
    using BookShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class PurchaiseViewModel
    {
        public int Id { get; set; }

        public BookTitleViewModel Book { get; set; }

        public string Username { get; set; }

        public DateTime DateOfPurchaise { get; set; }

        public decimal Price { get; set; }

        public bool IsRecalled { get; set; }

        public static Expression<Func<Purchaise, PurchaiseViewModel>> Create
        {
            get
            {
                return p => new PurchaiseViewModel
                {
                    Id = p.Id,
                    Book = new BookTitleViewModel()
                        {
                            Title = p.Book.Title
                        },
                    Username = p.User.UserName,
                    DateOfPurchaise = p.DateOfPurchaise,
                    Price = p.Price,
                    IsRecalled = p.IsRecalled
                };
            }
        }
    }
}