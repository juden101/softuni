namespace BookShop.Services.Controllers
{
    using System.Web.Http;
    using System.Linq;
    using Models;
    using BookShop.Models;
    using System.Web.Http.Description;
    using System.Web.OData;

    public class AuthorsController : BaseApiController
    {
        // GET api/authors/{id}
        [HttpGet]
        [Route("api/authors/{id}")]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetAuthor([FromUri]int id)
        {
            var author = this.Data.Author.Where(a => a.Id == id).Select(AuthorViewModel.Create).FirstOrDefault();

            if (author == null)
            {
                return this.NotFound();
            }

            return this.Ok(author);
        }

        // POST api/authors
        [HttpPost]
        [Route("api/authors")]
        public IHttpActionResult AddPost([FromBody]AddAuthorBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model cannot be null (no data in request)");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var author = new Author()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            this.Data.Author.Add(author);
            this.Data.SaveChanges();

            var data = this.Data.Author
                .Where(a => a.Id == author.Id)
                .Select(AuthorViewModel.Create)
                .FirstOrDefault();

            return this.Ok(data);
        }

        // GET api/authors/{id}/books
        [HttpGet]
        [Route("api/authors/{id}/books")]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetAuthorBooks([FromUri]int id)
        {
            var author = this.Data.Author.Where(a => a.Id == id).FirstOrDefault();

            if (author == null)
            {
                return this.NotFound();
            }
            
            var authorBooks = this.Data.Books.Where(b => b.AuthorId == author.Id).Select(AuthorBooksViewModel.Create);

            return this.Ok(authorBooks);
        }
    }
}