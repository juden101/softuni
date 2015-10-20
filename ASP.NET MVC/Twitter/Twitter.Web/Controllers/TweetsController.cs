namespace Twitter.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web.Mvc;
    using Twitter.Models;
    using Models.ViewModels;
    using Models.BindingModels;

    [Authorize]
    public class TweetsController : BaseController
    {
        [OutputCache(Duration = 5 * 60)]
        public ActionResult CreateTweet()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTweet(CreateTweetBindingModel model)
        {
            if (this.ModelState.IsValid && this.ModelState != null)
            {
                var loggedUserId = User.Identity.GetUserId();

                var tweet = new Tweet
                {
                    Content = model.Content,
                    CreatedAt = DateTime.Now,
                    AuthorId = loggedUserId
                };

                this.Data.Tweets.Add(tweet);
                this.Data.SaveChanges();
                this.TempData["SuccessMessage"] = "Tweet successfully created!";

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}