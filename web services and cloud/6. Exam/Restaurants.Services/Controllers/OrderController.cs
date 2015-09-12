using Microsoft.AspNet.Identity;
using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Restaurants.Services.Controllers
{
    public class OrderController : BaseApiController
    {
        // POST: api/meals/{id}/order
        [HttpPost]
        [Route("api/meals/{id}/order")]
        [Authorize]
        public IHttpActionResult CreateOrder(int id, [FromBody]AddOrderBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing order data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Quantity < 1)
            {
                return this.BadRequest("Cannot order negative quantity.");
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var meal = this.Data.Meals.Find(id);

            if (meal == null)
            {
                return BadRequest("Meal does not exist.");
            }

            var order = new Order()
            {
                UserId = user.Id,
                Quantity = model.Quantity,
                OrderStatus = OrderStatus.Pending,
                MealId = meal.Id,
                CreatedOn = DateTime.Now
            };

            this.Data.Orders.Add(order);
            this.Data.SaveChanges();
            
            return this.Ok();
        }

        // GET api/orders?startPage={start-page}&limit={page-size}&mealId={mealId}
        [HttpGet]
        [Route("api/orders")]
        [Authorize]
        public IHttpActionResult GetPendingOrders([FromUri]FilterOrdersBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing order data.");
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

            var orders = this.Data.Orders
                .All()
                .Where(o => o.UserId == userId && o.OrderStatus == OrderStatus.Pending)
                .AsQueryable();

            var meal = this.Data.Meals.Find(model.MealId);

            if (meal != null)
            {
                orders = orders.Where(o => o.MealId == model.MealId);
            }

            var data = orders
                .OrderBy(o => o.CreatedOn)
                .Skip(model.StartPage * model.Limit)
                .Take(model.Limit)
                .Select(o => new
                {
                    Id = o.Id,
                    Meal = new
                    {
                        Id = o.Meal.Id,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    },
                    Quantity = o.Quantity,
                    Status = o.OrderStatus,
                    CreatedOn = o.CreatedOn
                });

            return this.Ok(data);
        }
    }
}