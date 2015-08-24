namespace BookShop.Services.Models
{
    using OnlineShop.Models;
    using System;
    using System.Linq.Expressions;

    public class AdOwnerViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public static Expression<Func<ApplicationUser, AdOwnerViewModel>> Create
        {
            get
            {
                return ao => new AdOwnerViewModel
                {
                    Id = ao.Id,
                    Username = ao.UserName
                };
            }
        }
    }
}