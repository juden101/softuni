namespace BookShop.Services.Models
{
    using OnlineShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class AdViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public AdOwnerViewModel Owner { get; set; }

        public string Type { get; set; }

        public DateTime PostedOn { get; set; }

        public IEnumerable<AdCategoryViewModel> Categories { get; set; }

        public static Expression<Func<Ad, AdViewModel>> Create
        {
            get
            {
                return a => new AdViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Price = a.Price,
                    Owner = new AdOwnerViewModel()
                    {
                        Id = a.OwnerId,
                        Username = a.Owner.UserName
                    },
                    Type = a.Type.Name,
                    PostedOn = a.PostedOn,
                    Categories = a.Categories
                        .Select(c => new AdCategoryViewModel()
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                };
            }
        }
    }
}