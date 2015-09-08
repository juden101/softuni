namespace OnlineShop.Services.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.UnitOfWork;
    using Infrastructure;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new OnlineShopData(new OnlineShopEntities()), new AspNetUserIdProvider())
        {
        }

        public BaseApiController(IOnlineShopData data, IUserIdProvider userIdProvider)
        {
            this.Data = data;
            this.UserIdProvider = userIdProvider;
        }

        protected IOnlineShopData Data { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }
    }
}