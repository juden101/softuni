using News.Services.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using News.Models;
using News.Services.Models.ViewModels;
using System.Web.Http.Description;

namespace News.Services.Controllers
{
    public class NewsController : BaseApiController
    {
        // GET api/news
        [HttpGet]
        [Route("api/news")]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetAllNews()
        {
            var allNews = this.Data.News.All()
                .OrderByDescending(n => n.PublishDate)
                .AsEnumerable()
                .Select(ShortNewsDataViewModel.Create);

            return this.Ok(allNews);
        }

        // POST api/news
        [HttpPost]
        [Route("api/news")]
        public IHttpActionResult AddNews([FromBody]AddNewsBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var news = new News.Models.News()
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = DateTime.Now
            };

            this.Data.News.Add(news);
            this.Data.SaveChanges();

            var result = this.Data.News
                .All()
                .Where(n => n.Id == news.Id)
                .AsEnumerable()
                .Select(DetailedNewsDataViewModel.Create);

            return this.Ok(result);
        }

        // PUT api/news/{id}
        [Route("api/news/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateNews(int id, [FromBody]EditNewsBindingModel model)
        {
            var news = this.Data.News.GetById(id);

            if (news == null)
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
            
            news.Title = model.Title;
            news.Content = model.Content;
            news.PublishDate = model.PublishDate;
            
            this.Data.SaveChanges();

            var result = this.Data.News
                .All()
                .Where(n => n.Id == news.Id)
                .AsEnumerable()
                .Select(DetailedNewsDataViewModel.Create);

            return this.Ok(result);
        }

        // DELETE api/news/{id}
        [Route("api/news/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteNews(int id)
        {
            var news = this.Data.News.GetById(id);

            if (news == null)
            {
                return this.NotFound();
            }

            this.Data.News.Delete(news);
            this.Data.SaveChanges();

            return this.Ok("News deleted.");
        }
    }
}