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
    public class MoviesController : BaseApiController
    {
        // GET api/movies/getAllMovies 
        [Route("api/movies/getAllMovies")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetAllMovies()
        {
            var allMovies = this.Data.Movies.All()
                .AsEnumerable()
                .Select(ShortMovieDataViewModel.Create);

            return this.Ok(allMovies);
        }

        // GET api/movies/{id}
        [Route("api/movies/{id}")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetMovieById(int id)
        {
            var movie = this.Data.Movies.All()
                .Where(m => m.Id == id)
                .Select(DetailedMovieDataViewModel.Create)
                .FirstOrDefault();

            if (movie == null)
            {
                return this.NotFound();
            }

            return this.Ok(movie);
        }

        // GET api/movies/genre/{id}
        [Route("api/movies/genre/{id}")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetUsersByGender(int id)
        {
            var genre = this.Data.Genres.All().Where(g => g.Id == id).FirstOrDefault();
            if (genre == null)
            {
                return this.NotFound();
            }

            var moviesByGenre = this.Data.Movies.All()
                .Where(m => m.Genre.Id == id)
                .AsEnumerable()
                .Select(ShortMovieDataViewModel.Create);

            return this.Ok(moviesByGenre);
        }

        // POST api/movies
        [Route("api/movies")]
        [HttpPost]
        public IHttpActionResult AddMovie([FromBody]AddMovieBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            ICollection<Actor> movieActors = new HashSet<Actor>();

            foreach (int actorId in model.Actors)
            {
                var currentActor = this.Data.Actors.All().Where(a => a.Id == actorId).FirstOrDefault();
                movieActors.Add(currentActor);
            }

            ICollection<Review> movieReviews = new HashSet<Review>();

            foreach (int reviewId in model.Reviews)
            {
                var currentReview = this.Data.Reviews.All().Where(r => r.Id == reviewId).FirstOrDefault();
                movieReviews.Add(currentReview);
            }

            Genre movieGenre = this.Data.Genres.All().Where(g => g.Id == model.Genre).FirstOrDefault();

            var movie = new Movie()
            {
                Title = model.Title,
                Length = model.Length,
                Ration = model.Ration,
                Country = model.Country,
                Actors = movieActors,
                Reviews = movieReviews,
                Genre = movieGenre
            };

            this.Data.Movies.Add(movie);
            this.Data.SaveChanges();

            var result = this.Data.Movies
                .All()
                .Where(m => m.Id == movie.Id)
                .AsEnumerable()
                .Select(DetailedMovieDataViewModel.Create);

            return this.Ok(result);
        }

        // PUT api/movies/{id}
        [Route("api/movies/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, [FromBody]AddMovieBindingModel model)
        {
            var movie = this.Data.Movies.All().Where(m => m.Id == id).FirstOrDefault();

            if (movie == null)
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

            ICollection<Actor> movieActors = new HashSet<Actor>();

            foreach (int actorId in model.Actors)
            {
                var currentActor = this.Data.Actors.All().Where(a => a.Id == actorId).FirstOrDefault();
                movieActors.Add(currentActor);
            }

            ICollection<Review> movieReviews = new HashSet<Review>();

            foreach (int reviewId in model.Reviews)
            {
                var currentReview = this.Data.Reviews.All().Where(r => r.Id == reviewId).FirstOrDefault();
                movieReviews.Add(currentReview);
            }

            Genre movieGenre = this.Data.Genres.All().Where(g => g.Id == model.Genre).FirstOrDefault();
            
            movie.Title = model.Title;
            movie.Length = model.Length;
            movie.Ration = model.Ration;
            movie.Country = model.Country;
            movie.Actors = movieActors;
            movie.Reviews = movieReviews;
            movie.Genre = movieGenre;

            this.Data.Movies.Add(movie);
            this.Data.SaveChanges();

            var result = this.Data.Movies
                .All()
                .Where(m => m.Id == movie.Id)
                .AsEnumerable()
                .Select(DetailedMovieDataViewModel.Create);

            return this.Ok(result);
        }

        // DELETE api/movies/{id}
        [Route("api/movies/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = this.Data.Movies.All().Where(m => m.Id == id).FirstOrDefault();

            if (movie == null)
            {
                return this.NotFound();
            }

            this.Data.Movies.Delete(movie);
            this.Data.SaveChanges();

            return this.Ok("Movie deleted.");
        }
    }
}