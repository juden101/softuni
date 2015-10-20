namespace Twitter.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web.Mvc;
    using Twitter.Models;
    using Models.ViewModels;

    [Authorize]
    public class TweetsController : BaseController
    {
        public ActionResult CreateTweet()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTweet(CreateTweetViewModel model)
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

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}