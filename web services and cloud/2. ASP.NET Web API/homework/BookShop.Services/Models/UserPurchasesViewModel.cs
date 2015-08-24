namespace BookShop.Services.Models
{
    using BookShop.Models;
    using System;
    using System.Linq.Expressions;

    public class UserPurchasesViewModel
    {
        public string Username { get; set; }
        
        public string BookTitle { get; set; }

        public decimal PurchasePrice { get; set; }
        
        public DateTime DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }

        public static Expression<Func<Purchaise, UserPurchasesViewModel>> Create
        {
            get
            {
                return p => new UserPurchasesViewModel
                {
                    Username = p.User.UserName,
                    BookTitle = p.Book.Title,
                    PurchasePrice = p.Book.Price,
                    DateOfPurchase = p.DateOfPurchaise,
                    IsRecalled = p.IsRecalled
                };
            }
        }
    }
}