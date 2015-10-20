namespace Twitter.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Web.Mvc;
    using Models.ViewModels;
    using Models.BindingModels;

    [Authorize]
    public class ProfileController : BaseController
    {
        public ActionResult Index()
        {
            var loggedUserId = User.Identity.GetUserId();
            var user = this.Data.ApplicationUsers.GetById(loggedUserId);

            var tweets = user.OwnTweets
                .OrderByDescending(t => t.CreatedAt)
                .AsQueryable()
                .Select(UserTweetViewModel.Create);

            return View(tweets);
        }
        
        [OutputCache(Duration = 5 * 60)]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProfileBindingModel model)
        {
            var loggedUserId = User.Identity.GetUserId();
            var profile = Data.ApplicationUsers.GetById(loggedUserId);

            if (model.FullName != null)
            {
                profile.FullName = model.FullName;
            }

            if (model.AvatarUrl != null)
            {
                profile.AvatarUrl = model.AvatarUrl;
            }

            if (model.Biography != null)
            {
                profile.Biography = model.Biography;
            }

            if (model.BirthDay != null)
            {
                profile.BirthDay = model.BirthDay;
            }

            if (model.Website != null)
            {
                profile.Website = model.Website;
            }

            this.Data.SaveChanges();
            this.TempData["SuccessMessage"] = "Profile successfully edited!";

            return RedirectToAction("Index", "Profile");
        }
    }
}