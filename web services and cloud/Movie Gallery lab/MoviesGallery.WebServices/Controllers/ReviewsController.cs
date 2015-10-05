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
    public class ReviewsController : BaseApiController
    {
        // GET api/reviews/getReviewsByMovie/{id} 
        [Route("api/reviews/getReviewsByMovie/{id}")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult getReviewsByMovie(int id)
        {
            var movie = this.Data.Movies.All().Where(m => m.Id == id).FirstOrDefault();
            if (movie == null)
            {
                return this.NotFound();
            }

            var reviewsByMovie = this.Data.Movies.All()
                .Where(m => m.Id == id)
                .AsEnumerable()
                .Select(m => m.Reviews.Select(ShortReviewDataViewModel.Create));

            return this.Ok(reviewsByMovie);
        }

        // POST api/reviews
        [Route("api/reviews")]
        [HttpPost]
        public IHttpActionResult AddReview([FromBody]AddReviewBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = this.Data.Users.All().Where(u => u.Id == model.UserId).FirstOrDefault();
            if (user == null)
            {
                return this.BadRequest("User does not exist");
            }

            var movie = this.Data.Movies.All().Where(m => m.Id == model.MovieId).FirstOrDefault();
            if (movie == null)
            {
                return this.BadRequest("Movie does not exist");
            }

            var review = new Review()
            {
                Content = model.Content,
                Movie = movie,
                User = user,
                DateOfCreation = DateTime.Now
            };

            this.Data.Reviews.Add(review);
            this.Data.SaveChanges();

            var result = this.Data.Reviews
                .All()
                .Where(r => r.Id == review.Id)
                .AsEnumerable()
                .Select(DetailedReviewDataViewModel.Create);

            return this.Ok(result);
        }

        // PUT api/reviews/{id}
        [Route("api/reviews/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateReview(int id, [FromBody]AddReviewBindingModel model)
        {
            var review = this.Data.Reviews.All().Where(r => r.Id == id).FirstOrDefault();

            if (review == null)
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

            var user = this.Data.Users.All().Where(u => u.Id == model.UserId).FirstOrDefault();
            if (user == null)
            {
                return this.BadRequest("User does not exist");
            }

            var movie = this.Data.Movies.All().Where(m => m.Id == model.MovieId).FirstOrDefault();
            if (movie == null)
            {
                return this.BadRequest("Movie does not exist");
            }

            review.Content = model.Content;
            review.Movie = movie;
            review.User = user;
            review.DateOfCreation = DateTime.Now;
            
            this.Data.SaveChanges();

            var result = this.Data.Reviews
                .All()
                .Where(r => r.Id == review.Id)
                .AsEnumerable()
                .Select(DetailedReviewDataViewModel.Create);

            return this.Ok(result);
        }

        // DELETE api/reviews/{id}
        [Route("api/reviews/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteReview(int id)
        {
            var review = this.Data.Reviews.All().Where(r => r.Id == id).FirstOrDefault();

            if (review == null)
            {
                return this.NotFound();
            }

            this.Data.Reviews.Delete(review);
            this.Data.SaveChanges();

            return this.Ok("Review deleted.");
        }
    }
}