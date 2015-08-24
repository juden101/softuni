namespace BookShop.Services.Models
{
    using OnlineShop.Models;
    using System;
    using System.Linq.Expressions;

    public class AdCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Category, AdCategoryViewModel>> Create
        {
            get
            {
                return ac => new AdCategoryViewModel
                {
                    Id = ac.Id,
                    Name = ac.Name
                };
            }
        }
    }
}