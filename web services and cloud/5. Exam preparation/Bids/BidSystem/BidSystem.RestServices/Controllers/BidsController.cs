using BidSystem.Data;
using BidSystem.Data.Models;
using BidSystem.Data.UnitOfWork;
using BidSystem.RestServices.Infrastructure;
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
    public class BidsController : BaseApiController
    {
        public BidsController()
            : base(new BidSystemData(new BidSystemDbContext()))
        {
        }

        public BidsController(IBidSystemData data)
            : base(data)
        {
        }

        // GET api/bids/my
        [HttpGet]
        [Route("api/bids/my")]
        [Authorize]
        public IHttpActionResult GetUserBids()
        {
            var userId = this.User.Identity.GetUserId();

            var bids = this.Data.Bids
                .All()
                .OrderBy(b => b.Date)
                .Where(b => b.Bidder.Id == userId)
                .Select(BidsViewModel.Create);

            return this.Ok(bids);
        }

        // GET api/bids/won
        [HttpGet]
        [Route("won")]
        [Authorize]
        public IHttpActionResult GetUserWonBids()
        {
            var userId = this.User.Identity.GetUserId();

            var bids = this.Data.Bids
                .All()
                .OrderBy(b => b.Date)
                .Where(b =>
                    b.Bidder.Id == userId &&
                    b.Offer.ExpirationDate < DateTime.Now &&
                    b.Offer.Bids.
                        OrderByDescending(bb => bb.Price)
                        .Select(bb => bb.Bidder.Id)
                        .FirstOrDefault() == userId)
                .Select(BidsViewModel.Create);

            return this.Ok(bids);
        }

        // POST: api/offers/{id}/bid
        [HttpPost]
        [Route("api/offers/{id}/bid")]
        [Authorize]
        public IHttpActionResult CreateBid(int id,  [FromBody]AddBidBindingModel bidData)
        {
            if (bidData == null)
            {
                return BadRequest("Missing bid data.");
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

            var offer = this.Data.Offers.Find(id);

            if (offer == null)
            {
                return this.NotFound();
            }

            if (offer.ExpirationDate < DateTime.Now)
            {
                return this.BadRequest("Offer has expired.");
            }

            if (bidData.BidPrice < offer.InitialPrice)
            {
                return this.BadRequest("Your bid should be > " + offer.InitialPrice);
            }

            if (offer.Bids.Count > 0 && bidData.BidPrice <= offer.Bids.Max(b => b.Price))
            {
                return this.BadRequest("Your bid should be > " + offer.Bids.Max(b => b.Price));
            }

            var bid = new Bid()
            {
                Price = bidData.BidPrice,
                Comment = bidData.Comment,
                Bidder = user,
                Date = DateTime.Now
            };

            offer.Bids.Add(bid);
            this.Data.SaveChanges();

            return this.Ok(new
            {
                Id = bid.Id,
                Bidder = user.UserName,
                Message = "Bid created."
            });
        }
    }
}