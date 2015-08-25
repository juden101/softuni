using BookShop.Services.Models;
using Microsoft.AspNet.Identity;
using OnlineShop.Models;
using OnlineShop.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;

namespace OnlineShop.Services.Controllers
{
    [Authorize]
    public class AdsController : BaseApiController
    {
        // GET api/ads
        [HttpGet]
        [Route("api/ads")]
        [AllowAnonymous]
        [EnableQuery]
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads
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
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            
            if (model.Categories.Count() > 3)
            {
                return this.BadRequest("Categories have to be between 1 and 3");
            }

            var allCategories = this.Data.Categories;
            var currentAdCategories = new HashSet<Category>();
            foreach (var categoryId in model.Categories)
            {
                var currentCategory = allCategories.Where(c => c.Id == categoryId).FirstOrDefault();
                if (currentCategory == null)
                {
                    return this.BadRequest("Invalid category");
                }

                currentAdCategories.Add(currentCategory);
            }
            
            if (!this.Data.AdTypes.Where(at => at.Id == model.TypeId).Any())
            {
                return this.BadRequest("Invalid ad type");
            }

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                PostedOn = DateTime.Now,
                OwnerId = User.Identity.GetUserId(),
                TypeId = model.TypeId,
                Categories = currentAdCategories
            };

            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var result = this.Data.Ads
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create);

            return this.Ok(result);
        }

        // PUT api/ads/{id}/close
        [HttpPut]
        [Route("api/ads/{id}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            Ad ad = this.Data.Ads.Where(a => a.Id == id).FirstOrDefault();
            if (ad == null)
            {
                this.NotFound();
            }

            string userId = User.Identity.GetUserId();
            if (ad.Owner.Id != userId)
            {
                this.Unauthorized();
            }

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;

            this.Data.SaveChanges();

            var result = this.Data.Ads
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create);

            return this.Ok(result);
        }
    }
}