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
    public class ActorsController : BaseApiController
    {
        // GET api/actors/getActorByMovie/{id} 
        [Route("api/actors/getActorsByMovie/{id}")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult getActorsByMovie(int id)
        {
            var movie = this.Data.Movies.All().Where(m => m.Id == id).FirstOrDefault();
            if (movie == null)
            {
                return this.NotFound();
            }

            var actorsByMovie = this.Data.Movies.All()
                .Where(m => m.Id == id)
                .AsEnumerable()
                .Select(m => m.Actors.Select(ShortActorDataViewModel.Create));

            return this.Ok(actorsByMovie);
        }

        // GET api/actor/{id}
        [Route("api/actors/{id}")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetActorById(int id)
        {
            var actor = this.Data.Actors.All()
                .Where(a => a.Id == id)
                .Select(DetailedActorDataViewModel.Create)
                .FirstOrDefault();

            if (actor == null)
            {
                return this.NotFound();
            }
            
            return this.Ok(actor);
        }

        // POST api/actors
        [Route("api/actors")]
        [HttpPost]
        public IHttpActionResult AddActor([FromBody]AddActorBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            ICollection<Movie> actorMovies = new HashSet<Movie>();

            foreach (int movieId in model.Movies)
            {
                var currentMovie = this.Data.Movies.All().Where(m => m.Id == movieId).FirstOrDefault();
                actorMovies.Add(currentMovie);
            }

            var actor = new Actor()
            {
                Name = model.Name,
                BornDate = model.BornDate,
                Biography = model.Biography,
                HomeTown = model.Hometown,
                Movies = actorMovies
            };

            this.Data.Actors.Add(actor);
            this.Data.SaveChanges();

            var result = this.Data.Actors
                .All()
                .Where(a => a.Id == actor.Id)
                .AsEnumerable()
                .Select(DetailedActorDataViewModel.Create);

            return this.Ok(result);
        }

        // PUT api/actors/{id}
        [Route("api/actors/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateActor(int id, [FromBody]AddActorBindingModel model)
        {
            var actor = this.Data.Actors.All().Where(a => a.Id == id).FirstOrDefault();

            if (actor == null)
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

            ICollection<Movie> actorMovies = new HashSet<Movie>();

            foreach (int movieId in model.Movies)
            {
                var currentMovie = this.Data.Movies.All().Where(m => m.Id == movieId).FirstOrDefault();
                actorMovies.Add(currentMovie);
            }

            actor.Name = model.Name;
            actor.BornDate = model.BornDate;
            actor.Biography = model.Biography;
            actor.HomeTown = model.Hometown;
            actor.Movies = actorMovies;
            
            this.Data.SaveChanges();

            var result = this.Data.Actors
                .All()
                .Where(a => a.Id == actor.Id)
                .AsEnumerable()
                .Select(DetailedActorDataViewModel.Create);

            return this.Ok(result);
        }

        // DELETE api/actors/{id}
        [Route("api/actors/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteActor(int id)
        {
            var actor = this.Data.Actors.All().Where(a => a.Id == id).FirstOrDefault();

            if (actor == null)
            {
                return this.NotFound();
            }

            this.Data.Actors.Delete(actor);
            this.Data.SaveChanges();

            return this.Ok("Actor deleted.");
        }
    }
}