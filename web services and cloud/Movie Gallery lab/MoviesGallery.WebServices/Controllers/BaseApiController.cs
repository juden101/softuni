namespace MoviesGallery.WebServices.Controllers
{
    using MoviesGallery.Data;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new MoviesGalleryData())
        {
        }

        public BaseApiController(IMoviesGalleryData data)
        {
            this.Data = data;
        }

        protected IMoviesGalleryData Data { get; set; }
    }
}