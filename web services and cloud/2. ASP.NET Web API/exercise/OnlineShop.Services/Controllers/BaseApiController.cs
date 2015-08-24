namespace OnlineShop.Services.Controllers
{
    using System.Web.Http;
    using Data;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new OnlineShopEntities())
        {
        }

        public BaseApiController(OnlineShopEntities data)
        {
            this.Data = data;
        }

        protected OnlineShopEntities Data { get; set; }
    }
}