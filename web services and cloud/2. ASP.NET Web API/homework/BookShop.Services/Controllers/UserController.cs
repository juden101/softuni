namespace BookShop.Services.Controllers
{
    using System.Linq;
    using Models;
    using BookShop.Models;
    using System.Web.Http;
    using System.Collections.Generic;
    using System;
    using System.Web.OData;
    using System.Web.Http.Description;
    using Microsoft.AspNet.Identity;
    using System.Data.Entity.Core.Objects;

    public class UserController : BaseApiController
    {
        // GET api/user/{username}/purchases
        [Route("api/user/{username}/purchases")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetUserPurchases(string username)
        {
            string loggedUserId = this.User.Identity.GetUserId();

            if (loggedUserId == null)
            {
                return this.Unauthorized();
            }

            var user = this.Data.Users.Where(u => u.Id == loggedUserId).FirstOrDefault();

            if (user == null)
            {
                return this.Unauthorized();
            }

            var purchases = this.Data.Purchaises
                .Where(p => p.User.Id == user.Id)
                .OrderBy(p => p.DateOfPurchaise)
                .Select(UserPurchasesViewModel.Create);

            return this.Ok(purchases);
        }
    }
}