namespace BookShop.Services.Models
{
    using BookShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Category, CategoryViewModel>> Create
        {
            get
            {
                return c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                };
            }
        }
    }
}