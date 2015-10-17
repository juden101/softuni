namespace Twitter.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        // GET: Administration/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}