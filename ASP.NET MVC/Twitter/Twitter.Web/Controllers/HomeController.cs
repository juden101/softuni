namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Mvc;
    using Models.BindingModels;
    using Models.ViewModels;

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
                .Take(5)
                .AsQueryable()
                .Select(UserTweetViewModel.Create);

            return View(tweets);
        }
    }
}