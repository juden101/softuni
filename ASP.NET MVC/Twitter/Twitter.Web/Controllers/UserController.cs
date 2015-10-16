namespace Twitter.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Net;
    using System.Web.Mvc;
    using Twitter.Models;
    using Models.ViewModels;
    using Models.BindingModels;

    public class UserController : BaseController
    {
        [Authorize]
        public ActionResult UserProfile()
        {
            var user = this.Data.ApplicationUsers.GetById(this.User.Identity.GetUserId());
            var viewModel = new UserViewModel()
            {
                UserName = user.UserName
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTweet(TweetBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Data");
            }

            Tweet tweet = new Tweet
            {
                Content = model.Content,
                CreatedOn = DateTime.Now,
                Author = this.Data.ApplicationUsers.GetById(this.User.Identity.GetUserId())
            };

            this.Data.Tweets.Add(tweet);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }
    }
}