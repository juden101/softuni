using MoviesGallery.Models;
using MoviesGallery.WebServices.Models;
using MoviesGallery.WebServices.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace MoviesGallery.WebServices.Controllers
{
    public class GenresController : BaseApiController
    {
        // GET api/genres/getAllGenres
        [Route("api/genres/getAllGenres")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetAllGenres()
        {
            var allGenres = this.Data.Genres.All()
                .AsEnumerable()
                .Select(DetailedGenreDataViewModel.Create);

            return this.Ok(allGenres);
        }

        // POST api/genres
        [Route("api/genres")]
        [HttpPost]
        public IHttpActionResult AddGenre([FromBody]AddGenreBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var genre = new Genre()
            {
                Name = model.Name
            };

            this.Data.Genres.Add(genre);
            this.Data.SaveChanges();

            var result = this.Data.Genres
                .All()
                .Where(g => g.Id == genre.Id)
                .AsEnumerable()
                .Select(DetailedGenreDataViewModel.Create);

            return this.Ok(result);
        }

        // PUT api/genres/{id}
        [Route("api/genres/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateGenres(int id, [FromBody]AddGenreBindingModel model)
        {
            var genre = this.Data.Genres.All().Where(g => g.Id == id).FirstOrDefault();

            if (genre == null)
            {
                return this.NotFound();
            }

            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            genre.Name = model.Name;
            this.Data.SaveChanges();

            var result = this.Data.Genres
                .All()
                .Where(g => g.Id == genre.Id)
                .AsEnumerable()
                .Select(DetailedGenreDataViewModel.Create);

            return this.Ok(result);
        }

        // DELETE api/genres/{id}
        [Route("api/genres/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteGenre(int id)
        {
            var genre = this.Data.Genres.All().Where(g => g.Id == id).FirstOrDefault();

            if (genre == null)
            {
                return this.NotFound();
            }

            this.Data.Genres.Delete(genre);
            this.Data.SaveChanges();

            return this.Ok("Genre deleted.");
        }
    }
}