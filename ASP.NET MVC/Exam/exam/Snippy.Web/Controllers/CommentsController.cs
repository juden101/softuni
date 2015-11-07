using Microsoft.AspNet.Identity;
using Snippy.Data.UnitOfWork;
using Snippy.Models;
using Snippy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snippy.Web.Controllers
{
    [Authorize]
    public class CommentsController : BaseController
    {
        public CommentsController(ISnippyData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int snippedId, string comment)
        {
            if (comment == string.Empty)
            {
                return RedirectToAction("Details", "Snippets", new { id = snippedId });
            }

            var snippet = this.Data.Snippets.All().Where(s => s.Id == snippedId).FirstOrDefault();

            if (snippet == null)
            {
                return HttpNotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();

            var newComment = new Comment()
            {
                AuthorId = loggedUserId,
                CreatedOn = DateTime.Now,
                Content = comment,
                Snippet = snippet
            };

            this.Data.Comments.Add(newComment);
            this.Data.SaveChanges();

            return RedirectToAction("Details", "Snippets", new { id = snippedId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var comment = this.Data.Comments.All()
                .Where(c => c.Id == id)
                .Select(CommentViewModel.Create)
                .FirstOrDefault();

            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteComment(int id)
        {
            var comment = this.Data.Comments.All()
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (comment == null)
            {
                return HttpNotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();

            if (comment.AuthorId != loggedUserId)
            {
                return RedirectToAction("Details", "Snippets", new { id = id });
            }

            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();

            return RedirectToAction("Details", "Snippets", new { id = id });
        }
    }
}