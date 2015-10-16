namespace Twitter.Web.Controllers
{
    using System.Web.Mvc;
    using Twitter.Data;
    using Twitter.Data.UnitOfWork;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new TwitterSystemData(new TwitterDbContext()))
        {
        }

        public BaseController(ITwitterSystemData data)
        {
            this.Data = data;
        }

        protected ITwitterSystemData Data { get; }
    }
}