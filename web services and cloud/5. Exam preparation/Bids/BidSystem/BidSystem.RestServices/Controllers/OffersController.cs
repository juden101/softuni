using BidSystem.Data.Models;
using BidSystem.RestServices.Models.BindingModels;
using BidSystem.RestServices.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BidSystem.RestServices.Controllers
{
    [RoutePrefix("api/offers")]
    public class OffersController : BaseApiController
    {
        // GET api/offers/all
        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllOffers()
        {
            var offers = this.Data.Offers
                .OrderBy(o => o.PublishDate)
                .Select(OffersViewModel.Create);

            return this.Ok(offers);
        }

        // GET api/offers/active
        [HttpGet]
        [Route("active")]
        public IHttpActionResult GetActiveOffers()
        {
            var offers = this.Data.Offers
                .Where(o => o.ExpirationDate > DateTime.Now)
                .OrderBy(o => o.PublishDate)
                .Select(OffersViewModel.Create);

            return this.Ok(offers);
        }

        // GET api/offers/expired
        [HttpGet]
        [Route("expired")]
        public IHttpActionResult GetExpiredOffers()
        {
            var offers = this.Data.Offers
                .Where(o => o.ExpirationDate < DateTime.Now)
                .OrderBy(o => o.PublishDate)
                .Select(OffersViewModel.Create);

            return this.Ok(offers);
        }

        // GET api/offers/details/{id}
        [HttpGet]
        [Route("details/{id}")]
        public IHttpActionResult GetDetailedOffer(int id)
        {
            var offer = this.Data.Offers
                .Where(o => o.Id == id)
                .Select(DetailedOfferViewModel.Create)
                .FirstOrDefault();

            if (offer == null)
            {
                return this.NotFound();
            }

            return this.Ok(offer);
        }

        // GET api/offers/my
        [HttpGet]
        [Route("my")]
        [Authorize]
        public IHttpActionResult GetUserOffers()
        {
            var userId = this.User.Identity.GetUserId();

            var offers = this.Data.Offers
                .OrderBy(o => o.PublishDate)
                .Where(o => o.Seller.Id == userId)
                .Select(OffersViewModel.Create);

            return this.Ok(offers);
        }

        // POST: api/offers
        [HttpPost]
        [Route]
        [Authorize]
        public IHttpActionResult CreateOffer([FromBody]AddOfferBindingModel offerData)
        {
            if (offerData == null)
            {
                return BadRequest("Missing offer data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var offer = new Offer()
            {
                Title = offerData.Title,
                Description = offerData.Description,
                InitialPrice = offerData.InitialPrice,
                ExpirationDate = offerData.ExpirationDateTime,
                PublishDate = DateTime.Now,
                Seller = user
            };

            this.Data.Offers.Add(offer);
            this.Data.SaveChanges();
            
            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "offers", id = offer.Id },
                new
                {
                    Id = offer.Id,
                    Seller = offer.Seller.UserName,
                    Message = "Offer created."
                }
            );
        }
    }
}