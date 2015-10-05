namespace MoviesGallery.WebServices.Controllers
{
    using MoviesGallery.Models;
    using MoviesGallery.WebServices.Models;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.Http.OData;

    public class UsersController : BaseApiController
    {
        // GET api/users/getAllUsers 
        [Route("api/users/getAllUsers")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetAllUsers()
        {
            var allUsers = this.Data.Users.All()
                .AsEnumerable()
                .Select(ShortUserDataViewModel.Create);

            return this.Ok(allUsers);
        }

        // GET api/users/{id}
        [Route("api/users/{id}")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetUserById(string id)
        {
            var user = this.Data.Users.All()
                .Where(u => u.Id == id)
                .Select(DetailedUserDataViewModel.Create)
                .FirstOrDefault();

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

        // GET api/users/gender/{gender}
        [Route("api/users/gender/{gender}")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetUsersByGender(int gender)
        {
            var usersByGender = this.Data.Users.All()
                .Where(u => u.Gender == (Gender)gender)
                .AsEnumerable()
                .Select(ShortUserDataViewModel.Create);

            return this.Ok(usersByGender);
        }
    }
}