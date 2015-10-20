namespace Twitter.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;
    using Models.ViewModels;
    using System.Linq;

    [Authorize]
    public class UsersController : BaseController
    {
        [HttpGet]
        [OutputCache(Duration = 60)]
        public ActionResult All()
        {
            var loggedUserId = User.Identity.GetUserId();
            var users = this.Data.ApplicationUsers
                .All()
                .Where(u => u.Id != loggedUserId)
                .AsQueryable()
                .Select(UserViewModel.Create);

            return View(users);
        }
    }
}