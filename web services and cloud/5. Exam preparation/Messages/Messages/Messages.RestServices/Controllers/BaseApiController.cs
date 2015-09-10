namespace Messages.RestServices.Controllers
{
    using Messages.Data;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new MessagesDbContext())
        {
        }

        public BaseApiController(MessagesDbContext data)
        {
            this.Data = data;
        }

        protected MessagesDbContext Data { get; set; }
    }
}