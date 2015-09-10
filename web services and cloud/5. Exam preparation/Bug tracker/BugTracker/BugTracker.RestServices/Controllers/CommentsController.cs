using BugTracker.Data.Models;
using BugTracker.RestServices.Models.BindingModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BugTracker.RestServices.Controllers
{
    public class CommentsController : BaseApiController
    {
        // GET api/comments
        [HttpGet]
        [Route("api/comments")]
        public IHttpActionResult GetComments()
        {
            var comments = this.Data.Comments.OrderByDescending(c => c.DateCreated)
                .Select(c => new
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author != null ? c.Author.UserName : null,
                    DateCreated = c.DateCreated,
                    Bug = new
                    {
                        Id = c.Bug.Id,
                        Title = c.Bug.Title
                    }
                });

            return this.Ok(comments);
        }

        // GET: api/bugs/{id:int}/comments
        [HttpGet]
        [Route("api/bugs/{id:int}/comments")]
        public IHttpActionResult GetCommentsByBugId(int id)
        {
            Bug bug = this.Data.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            var bugComments = bug.Comments.OrderByDescending(bc => bc.DateCreated).Select(bc => new
            {
                Id = bc.Id,
                Text = bc.Text,
                Author = bc.Author != null ? bc.Author.UserName : null,
                DateCreated = bc.DateCreated
            });

            return Ok(bugComments);
        }

        // POST: api/bugs/{id:int}/comments
        [HttpPost]
        [Route("api/bugs/{id:int}/comments")]
        public IHttpActionResult CreateBugComment(int id, AddBugCommentBindingModel bugCommentData)
        {
            if (bugCommentData == null)
            {
                return BadRequest("Missing bug comment data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bug = this.Data.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            User user = null;
            var userId = this.User.Identity.GetUserId();

            if (userId != null)
            {
                user = this.Data.Users.Find(userId);
            }

            Comment bugComment = new Comment()
            {
                Text = bugCommentData.Text,
                DateCreated = DateTime.Now,
                Author = user
            };

            bug.Comments.Add(bugComment);
            this.Data.SaveChanges();

            if (user != null)
            {
                return this.Ok(new
                {
                    Id = bugComment.Id,
                    Author = user.UserName,
                    Message = "User comment added for bug #" + bug.Id
                });
            }

            return this.Ok(new
            {
                Id = bug.Id,
                Message = "Added anonymous comment for bug #" + bug.Id
            });
        }
    }
}