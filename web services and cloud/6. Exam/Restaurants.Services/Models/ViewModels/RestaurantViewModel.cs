using Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Restaurants.Services.Models.ViewModels
{
    public class RestarauntViewModel
    {
        public static Expression<Func<Restaurant, RestarauntViewModel>> Create
        {
            get
            {
                return r => new RestarauntViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = r.Ratings.Average(rr => rr.Stars),
                    Town = new TownViewModel()
                    {
                        Id = r.Town.Id,
                        Name = r.Town.Name
                    }
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public TownViewModel Town { get; set; }
    }
}