namespace Snippy.Web.Controllers
{
    using Snippy.Data.UnitOfWork;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        public BaseController(ISnippyData data)
        {
            this.Data = data;
        }

        protected ISnippyData Data { get; set; }
    }
}