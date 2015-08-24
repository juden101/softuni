namespace BookShop.Services.Controllers
{
    using System.Linq;
    using Models;
    using BookShop.Models;
    using System.Web.Http;
    using System.Collections.Generic;
    using System;
    using System.Web.Http.Description;
    using System.Web.OData;

    public class CategoriesController : BaseApiController
    {
        // GET api/categories
        [HttpGet]
        [Route("api/categories")]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetCategories()
        {
            var categories = this.Data.Category.Select(CategoryViewModel.Create);

            return this.Ok(categories);
        }

        // GET api/categories/{id}
        [HttpGet]
        [Route("api/categories/{id}")]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetCategory([FromUri]int id)
        {
            var category = this.Data.Category.Where(c => c.Id == id).Select(CategoryViewModel.Create).FirstOrDefault();

            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok(category);
        }

        // PUT api/categories/{id}
        [Route("api/categories/{id}")]
        [HttpPut]
        public IHttpActionResult EditCategory(int id,
            [FromBody]EditCategoryBindingModel model)
        {
            var category = this.Data.Category.Find(id);
            if (category == null)
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

            if (category.Name == model.Name)
            {
                return this.BadRequest("Category name must not be the same");
            }

            category.Name = model.Name;
            this.Data.SaveChanges();

            var result = this.Data.Category
                .Where(c => c.Id == category.Id)
                .Select(CategoryViewModel.Create);

            return this.Ok(result);
        }

        // DELETE api/categories/{id}
        [Route("api/categories/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = this.Data.Category.Find(id);
            if (category == null)
            {
                return this.NotFound();
            }

            this.Data.Category.Remove(category);
            this.Data.SaveChanges();

            return this.Ok("Category deleted.");
        }

        // POST api/categories
        [Route("api/categories")]
        [HttpPost]
        public IHttpActionResult AddCategory([FromBody]AddCategoryBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var allCategories = this.Data.Category;

            if (allCategories.Any(c => c.Name == model.Name))
            {
                return this.BadRequest("Category already exists");
            }

            var category = new Category()
            {
                Name = model.Name
            };

            allCategories.Add(category);
            this.Data.SaveChanges();

            var result = this.Data.Category
                .Where(c => c.Id == category.Id)
                .Select(CategoryViewModel.Create);

            return this.Ok(result);
        }
    }
}