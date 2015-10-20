namespace Twitter.Web.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class MessagesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}