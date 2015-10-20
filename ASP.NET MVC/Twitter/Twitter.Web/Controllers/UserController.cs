namespace Twitter.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;
    using Models.ViewModels;

    [Authorize]
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult AllUsers()
        {
            var users = this.Data.ApplicationUsers.All();

            return View(users);
        }
    }
}