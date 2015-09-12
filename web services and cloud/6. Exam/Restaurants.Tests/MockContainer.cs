using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Restaurants.Data.Repositories;
using Restaurants.Models;

namespace Restaurants.Tests
{
    public class MockContainer
    {
        public Mock<IRepository<Restaurant>> RestaurantRepositoryMock { get; set; }

        public void PrepareMock()
        {
            var fakeRestaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Restaurant 1",
                    TownId = 1,
                    Town = new Town
                    {
                        Id = 1,
                        Name = "Town #1"
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Stars = 5
                        },
                        new Rating
                        {
                            Stars = 3
                        },
                        new Rating
                        {
                            Stars = 8
                        }
                    }
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Restaurant 2",
                    TownId = 1,
                    Town = new Town
                    {
                        Id = 1,
                        Name = "Town #1"
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Stars = 2
                        },
                        new Rating
                        {
                            Stars = 1
                        },
                        new Rating
                        {
                            Stars = 3
                        }
                    }
                }
            };

            this.RestaurantRepositoryMock = new Mock<IRepository<Restaurant>>();
            this.RestaurantRepositoryMock.Setup(r => r.All())
                .Returns(fakeRestaurants.AsQueryable());

            this.RestaurantRepositoryMock.Setup(r => r.Update(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) =>
                {
                    var restaurantToUpdate = fakeRestaurants.FirstOrDefault(rr => rr.Id == restaurant.Id);
                    fakeRestaurants.Remove(restaurantToUpdate);
                    fakeRestaurants.Add(restaurant);
                });
        }
    }
}
