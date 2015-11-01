namespace Events.Web.Controllers
{
    using Events.Data;
    using System;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    [ValidateInput(false)]
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        public bool IsAdmin()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = (currentUserId != null && this.User.IsInRole("Administrator"));

            return isAdmin;
        }
    }
}