namespace News.Services.Controllers
{
    using System.Web.Http;
    using News.Data;

    public class BaseApiController : ApiController
    {
        private INewsData data;

        public BaseApiController()
            : this(new NewsData())
        {
        }

        public BaseApiController(INewsData data)
        {
            this.Data = data;
        }

        protected INewsData Data
        {
            get
            {
                return this.data;
            }

            private set
            {
                this.data = value;
            }
        }
    }
}