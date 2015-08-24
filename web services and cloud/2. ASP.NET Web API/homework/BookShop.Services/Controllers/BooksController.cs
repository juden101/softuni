namespace BookShop.Services.Controllers
{
    using System.Linq;
    using Models;
    using BookShop.Models;
    using System.Web.Http;
    using System.Collections.Generic;
    using System;
    using System.Web.OData;
    using System.Web.Http.Description;
    using Microsoft.AspNet.Identity;
    using System.Data.Entity.Core.Objects;

    public class BooksController : BaseApiController
    {
        // GET api/books/{id}
        [HttpGet]
        [Route("api/books/{id}")]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetBook([FromUri]int id)
        {
            var book = this.Data.Books.Where(b => b.Id == id).Select(BookViewModel.Create).FirstOrDefault();

            if (book == null)
            {
                return this.NotFound();
            }

            return this.Ok(book);
        }

        // GET api/books?search={word}
        [Route("api/books")]
        [HttpGet]
        [EnableQuery]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult SearchBooks(
            [FromUri]BookSearchBindingModel model)
        {
            if (model.Search == null)
            {
                return this.BadRequest("No seach criteria specified.");
            }

            var result = this.Data.Books
                .Where(b => b.Title.Contains(model.Search))
                .OrderBy(b => b.Title)
                .Select(SearchBookViewModel.Create)
                .Take(10);

            return this.Ok(result);
        }

        // PUT api/books/{id}
        [Route("api/books/{id}")]
        [HttpPut]
        public IHttpActionResult EditBook(int id,
            [FromBody]EditBookBindingModel model)
        {
            var book = this.Data.Books.Find(id);
            if (book == null)
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

            book.Title = model.Title;
            book.Description = model.Description;
            book.Price = model.Price;
            book.Copies = model.Copies;
            book.Type = model.Type;
            book.ReleaseDate = model.ReleaseDate;
            book.AgeRestriction = model.AgeRestriction;
            book.AuthorId = model.AuthorId;
            this.Data.SaveChanges();

            var result = this.Data.Books
                .Where(b => b.Id == book.Id)
                .Select(BookViewModel.Create);

            return this.Ok(result);
        }

        // DELETE api/books/{id}
        [Route("api/books/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = this.Data.Books.Find(id);
            if (book == null)
            {
                return this.NotFound();
            }

            this.Data.Books.Remove(book);
            this.Data.SaveChanges();

            return this.Ok("Book deleted.");
        }

        // POST api/books
        [Route("api/books")]
        [HttpPost]
        public IHttpActionResult AddBook([FromBody]AddBookBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            ICollection<Category> bookCategories = new HashSet<Category>();
            string[] categoryNames = model.Categories.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            foreach (string categoryName in categoryNames)
            {
                Category newCategory = new Category()
                {
                    Name = categoryName
                };

                bookCategories.Add(newCategory);
            }

            var book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                Copies = model.Copies,
                Type = model.Type,
                ReleaseDate = model.ReleaseDate,
                AgeRestriction = model.AgeRestriction,
                Categories = bookCategories,
                AuthorId = model.AuthorId
            };

            this.Data.Books.Add(book);
            this.Data.SaveChanges();

            var result = this.Data.Books
                .Where(b => b.Id == book.Id)
                .Select(BookViewModel.Create);

            return this.Ok(result);
        }

        // PUT api/books/buy/{id}
        [Route("api/books/buy/{id}")]
        [HttpPut]
        public IHttpActionResult BuyBook(int id)
        {
            string loggedUserId = this.User.Identity.GetUserId();

            if (loggedUserId == null)
            {
                return this.Unauthorized();
            }

            var user = this.Data.Users.Where(u => u.Id == loggedUserId).FirstOrDefault();

            if (user == null)
            {
                return this.Unauthorized();
            }

            var book = this.Data.Books.Where(b => b.Id == id).FirstOrDefault();

            if (book == null)
            {
                return this.NotFound();
            }

            if (book.Copies <= 0)
            {
                this.BadRequest("No book copies left");
            }

            var purchaise = new Purchaise()
            {
                Book = book,
                User = user,
                DateOfPurchaise = DateTime.Now,
                Price = book.Price,
                IsRecalled = false
            };

            book.Copies--;
            this.Data.Purchaises.Add(purchaise);
            this.Data.SaveChanges();

            var result = this.Data.Purchaises
                .Where(p => p.Id == purchaise.Id)
                .Select(PurchaiseViewModel.Create);

            return this.Ok(result);
        }
        
        // PUT api/books/recall/{id}
        [Route("api/books/recall/{id}")]
        [HttpPut]
        public IHttpActionResult RecallBook(int id)
        {
            string loggedUserId = this.User.Identity.GetUserId();

            if (loggedUserId == null)
            {
                return this.Unauthorized();
            }

            var user = this.Data.Users.Where(u => u.Id == loggedUserId).FirstOrDefault();

            if (user == null)
            {
                return this.Unauthorized();
            }

            var book = this.Data.Books.Where(b => b.Id == id).FirstOrDefault();

            if (book == null)
            {
                return this.NotFound();
            }

            var purchaise = this.Data.Purchaises.Where(p => p.Book.Id == book.Id && p.User.Id == user.Id && p.IsRecalled == false && EntityFunctions.DiffDays(p.DateOfPurchaise, p.DateOfPurchaise) < 30).FirstOrDefault();

            if (purchaise == null)
            {
                return this.NotFound();
            }

            book.Copies++;
            purchaise.IsRecalled = true;
            this.Data.SaveChanges();

            var result = this.Data.Purchaises
                .Where(p => p.Id == purchaise.Id)
                .Select(PurchaiseViewModel.Create);

            return this.Ok(result);
        }
    }
}