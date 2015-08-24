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
    public class AdsController : BaseApiController
    {
        [HttpGet]
        [Route("api/ads")]
        [Authorize]
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
        
        public IHttpActionResult CreateAd(CreateAdBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (userId == null)
            {
                return this.BadRequest("User is not logged.");
            }

            if(!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var ad = new Ad();


        }
    }
}