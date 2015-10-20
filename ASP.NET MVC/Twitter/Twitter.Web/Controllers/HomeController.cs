using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Twitter.Data.UnitOfWork;
using Twitter.Web.Models.BindingModels;
using Twitter.Web.Models.ViewModels;

namespace Twitter.Web.Controllers
{
    public class HomeController : BaseController
    {
        [System.Web.Mvc.Authorize]
        public ActionResult Index([FromUri]PaginationBindingModel model)
        {
            double tweetsCount = this.Data.Tweets.All().Count();
            int pagesCount = (int)Math.Ceiling(tweetsCount / 5);

            ViewBag.Title = "Home";
            ViewBag.TweetsCount = tweetsCount;
            ViewBag.PagesCount = pagesCount;

            var tweets = this.Data.Tweets.All()
                .OrderByDescending(t => t.CreatedAt)
                .Skip(model.StartPage * 5)
                .Take(5);

            return View(tweets);
        }
    }
}