namespace Messages.RestServices.Controllers
{
    using Messages.Data;
    using Data.UnitOfWork;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new MessagesData(new MessagesDbContext()))
        {
        }

        public BaseApiController(IMessagesData data)
        {
            this.Data = data;
        }

        protected IMessagesData Data { get; set; }
    }
}