namespace Twitter.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Linq;
    using System.Web.Mvc;
    using Models.ViewModels;

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
        
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProfileViewModel model)
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

            return RedirectToAction("Index", "Profile");
        }
    }
}