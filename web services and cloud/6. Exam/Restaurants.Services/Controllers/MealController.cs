using Microsoft.AspNet.Identity;
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
    public class MealController : BaseApiController
    {
        // GET api/restaurants/{id}/meals
        [HttpGet]
        [Route("api/restaurants/{id}/meals")]
        public IHttpActionResult GetRestaurantMeals(int id)
        {
            var restaurant = this.Data.Restaurants.Find(id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            var meals = restaurant.Meals
                .OrderBy(m => m.Type.Order)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Type = m.Type.Name
                });

            return this.Ok(meals);
        }

        // POST: api/meals
        [HttpPost]
        [Route("api/meals")]
        [Authorize]
        public IHttpActionResult CreateMeal([FromBody]AddMealBindingModel model)
        {
            if (model == null)
            {
                return BadRequest("Missing meal data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mealType = this.Data.MealTypes.Find(model.TypeId);

            if (mealType == null)
            {
                return this.BadRequest("Invalid meal type");
            }
            
            var restaurant = this.Data.Restaurants.Find(model.RestaurantId);

            if (restaurant == null)
            {
                return this.BadRequest("Invalid restaurant");
            }

            if (model.Price < 0)
            {
                return this.BadRequest("Price cannot be negative.");
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (user == null || restaurant.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            var meal = new Meal()
            {
                Name = model.Name,
                TypeId = mealType.Id,
                RestaurantId = restaurant.Id,
                Price = model.Price
            };

            this.Data.Meals.Add(meal);
            this.Data.SaveChanges();
            
            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "meals", id = meal.Id },
                new
                {
                    Id = meal.Id,
                    Name = meal.Name,
                    Price = meal.Price,
                    Type = meal.Type.Name
                }
            );
        }

        // PUT: api/meals
        [HttpPut]
        [Route("api/meals/{id}")]
        [Authorize]
        public IHttpActionResult EditMeal(int id, [FromBody]EditMealBindingModel model)
        {
            if (model == null)
            {
                return BadRequest("Missing meal data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meal = this.Data.Meals.Find(id);

            if (meal == null)
            {
                return this.NotFound();
            }

            var mealType = this.Data.MealTypes.Find(model.TypeId);

            if (mealType == null)
            {
                return this.BadRequest("Invalid meal type");
            }

            if (model.Price < 0)
            {
                return this.BadRequest("Price cannot be negative.");
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (user == null || meal.Restaurant.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            meal.Name = model.Name;
            meal.Price = model.Price;
            meal.Type = mealType;
            
            this.Data.SaveChanges();

            var output = this.Data.Meals.All().Where(m => m.Id == meal.Id).Select(MealViewModel.Create);

            return this.Ok(output);
        }

        // DELETE: api/meals/{id}
        [HttpDelete]
        [Route("api/meals/{id}")]
        [Authorize]
        public IHttpActionResult DeleteMeal(int id)
        {
            var meal = this.Data.Meals.Find(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (user == null || meal.Restaurant.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            this.Data.Meals.Remove(meal);
            this.Data.SaveChanges();

            return Ok(new
            {
                Message = "Meal #" + id + " deleted."
            });
        }
    }
}