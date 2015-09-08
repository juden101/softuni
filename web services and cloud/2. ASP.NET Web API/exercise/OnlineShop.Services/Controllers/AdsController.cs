using BookShop.Services.Models;
using Microsoft.AspNet.Identity;
using OnlineShop.Data.UnitOfWork;
using OnlineShop.Models;
using OnlineShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.Http.Description;
using OnlineShop.Services.Infrastructure;

namespace OnlineShop.Services.Controllers
{
    [Authorize]
    public class AdsController : BaseApiController
    {
        public AdsController()
            : base()
        {
        }

        public AdsController(IOnlineShopData onlineShopData, IUserIdProvider userIdProvider)
             : base(onlineShopData, userIdProvider)
        {
        }

        // GET api/ads
        [HttpGet]
        [Route("api/ads")]
        [AllowAnonymous]
        [EnableQuery]
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads.All()
                .Where(a => a.Status == AdStatus.Open)
                .OrderByDescending(a => a.Type.Index)
                .ThenByDescending(a => a.PostedOn)
                .Select(AdViewModel.Create);

            return this.Ok(ads);
        }

        // POST api/ads
        [HttpPost]
        [Route("api/ads")]
        public IHttpActionResult CreateAd(CreateAdBindingModel model)
        {
            string userId = this.UserIdProvider.GetUserId();
            if (userId == null)
            {
                return this.Unauthorized();
            }

            if (model == null)
            {
                return this.BadRequest("Ad model cannot be null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newAd = new Ad
            {
                Name = model.Name,
                Description = model.Description,
                TypeId = model.TypeId,
                Price = model.Price,
                PostedOn = DateTime.Now,
                OwnerId = userId
            };

            foreach (var categoryId in model.Categories)
            {
                var category = this.Data.Categories.Find(categoryId);
                newAd.Categories.Add(category);
            }

            this.Data.Ads.Add(newAd);
            this.Data.SaveChanges();

            var result = this.Data.Ads.All()
                .Where(a => a.Id == newAd.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }

        // PUT api/ads/{id}/close
        [HttpPut]
        [Route("api/ads/{id}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            Ad ad = this.Data.Ads.All().Where(a => a.Id == id).FirstOrDefault();
            if (ad == null)
            {
                this.NotFound();
            }

            string userId = UserIdProvider.GetUserId();
            if (ad.Owner.Id != userId)
            {
                this.BadRequest();
            }

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;

            this.Data.SaveChanges();

            var result = this.Data.Ads.All()
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create);

            return this.Ok(result);
        }
    }
}