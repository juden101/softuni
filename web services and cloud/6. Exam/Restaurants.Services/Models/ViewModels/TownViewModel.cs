using Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Restaurants.Services.Models.ViewModels
{
    public class TownViewModel
    {
        public static Expression<Func<Town, TownViewModel>> Create
        {
            get
            {
                return t => new TownViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}