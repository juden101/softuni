using Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Restaurants.Services.Models.ViewModels
{
    public class MealViewModel
    {
        public static Expression<Func<Meal, MealViewModel>> Create
        {
            get
            {
                return m => new MealViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Type = m.Type.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }
    }
}