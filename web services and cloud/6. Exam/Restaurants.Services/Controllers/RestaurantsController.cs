using Microsoft.AspNet.Identity;
using Restaurants.Data;
using Restaurants.Data.UnitOfWork;
using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;
using Restaurants.Services.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Restaurants.Services.Controllers
{
    public class RestaurantsController : BaseApiController
    {
        public RestaurantsController()
            : this(new RestaurantsData(new RestaurantsContext()))
        {
        }

        public RestaurantsController(IRestaurantsData data)
            : base(data)
        {
        }

        // GET api/restaurants?townId={townId}
        [HttpGet]
        [Route("api/restaurants")]
        public IHttpActionResult GetRestaurants(int townId)
        {
            var restaurants = this.Data.Restaurants
                .All()
                .Where(r => r.TownId == townId)
                .OrderByDescending(r => r.Ratings.Average(rr => rr.Stars))
                .ThenBy(r => r.Name)
                .Select(r => new
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = r.Ratings.Any() ? r.Ratings.Average(rr => rr.Stars) : 0,
                    Town = new
                    {
                        Id = r.Town.Id,
                        Name = r.Town.Name
                    }
                });

            return this.Ok(restaurants);
        }

        // POST: api/restaurants
        [HttpPost]
        [Route("api/restaurants")]
        [Authorize]
        public IHttpActionResult CreateRestaurant([FromBody]AddRestaurantBindingModel model)
        {
            if (model == null)
            {
                return BadRequest("Missing restaurant data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var town = this.Data.Towns.Find(model.TownId);

            if (town == null)
            {
                return BadRequest("Town does not exist.");
            }

            var restaurant = new Restaurant()
            {
                Name = model.Name,
                TownId = town.Id,
                OwnerId = userId
            };

            this.Data.Restaurants.Add(restaurant);
            this.Data.SaveChanges();
            
            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "restaurants", id = restaurant.Id },
                new
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Rating = restaurant.Ratings.FirstOrDefault(),
                    Town = new
                    {
                        Id = restaurant.Town.Id,
                        Name = restaurant.Town.Name
                    }
                }
            );
        }

        // POST: api/restaurants/{id}/rate
        [HttpPost]
        [Route("api/restaurants/{id}/rate")]
        [Authorize]
        public IHttpActionResult RateRestaurant(int id, [FromBody]RateRestaurantBindingModel model)
        {
            if (model == null)
            {
                return BadRequest("Missing rate data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var restaurant = this.Data.Restaurants.Find(id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            if (restaurant.OwnerId == userId)
            {
                return this.BadRequest("Restaurant owner cannot rate his restaurant.");
            }

            var oldRating = this.Data.Ratings.All().FirstOrDefault(r => r.UserId == userId && r.RestaurantId == id);

            if (oldRating == null)
            {
                var rating = new Rating()
                {
                    UserId = userId,
                    RestaurantId = id,
                    Stars = model.Stars
                };

                this.Data.Ratings.Add(rating);
                this.Data.SaveChanges();
            }
            else
            {
                oldRating.Stars = model.Stars;
                this.Data.SaveChanges();
            }

            return this.Ok();
        }
    }
}