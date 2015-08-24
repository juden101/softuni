namespace BookShop.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new BookShopContext())
        {
        }

        public BaseApiController(BookShopContext data)
        {
            this.Data = data;
        }

        protected BookShopContext Data { get; set; }
    }
}