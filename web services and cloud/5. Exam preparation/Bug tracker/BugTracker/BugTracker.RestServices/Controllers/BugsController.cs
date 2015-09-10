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
    [RoutePrefix("api/bugs")]
    public class BugsController : BaseApiController
    {
        // GET api/bugs
        [HttpGet]
        [Route]
        public IHttpActionResult GetBugs()
        {
            var bugs = this.Data.Bugs.OrderBy(b => b.DateCreated)
                .Select(b => new
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status.ToString(),
                    Author = b.Author != null ? b.Author.UserName : null,
                    DateCreated = b.DateCreated
                });

            return this.Ok(bugs);
        }

        // GET: api/bugs/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetBugById(int id)
        {
            Bug bug = this.Data.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            return Ok(new
            {
                Id = bug.Id,
                Title = bug.Title,
                Description = bug.Description,
                Status = bug.Status.ToString(),
                Author = bug.Author != null ? bug.Author.UserName : null,
                DateCreated = bug.DateCreated,
                Comments = bug.Comments
                    .Select(c => new
                    {
                        Id = c.Id,
                        Text = c.Text,
                        Author = c.Author != null ? c.Author.UserName : null,
                        DateCreated = c.DateCreated
                    })
            });
        }

        // POST: api/bugs
        [HttpPost]
        [Route]
        public IHttpActionResult CreateBug(AddBugBindingModel bugData)
        {
            if (bugData == null)
            {
                return BadRequest("Missing bug data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = null;
            var userId = this.User.Identity.GetUserId();

            if (userId != null)
            {
                user = this.Data.Users.Find(userId);
            }

            var bug = new Bug()
            {
                Title = bugData.Title,
                Description = bugData.Description,
                Status = BugStatus.Open,
                Author = user,
                DateCreated = DateTime.Now
            };

            this.Data.Bugs.Add(bug);
            this.Data.SaveChanges();

            if (user != null)
            {
                return this.CreatedAtRoute(
                    "DefaultApi",
                    new { controller = "bugs", id = bug.Id },
                    new
                    {
                        Id = bug.Id,
                        Author = bug.Author.UserName,
                        Message = "User bug submitted"
                    }
                );
            }

            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "bugs", id = bug.Id },
                new
                {
                    Id = bug.Id,
                    Message = "Anonymous  bug submitted"
                }
            );
        }

        // PATCH: api/bugs/{id}
        [HttpPatch]
        [Route("{id:int}")]
        public IHttpActionResult EditBug(int id, EditBugBindingModel bugData)
        {
            var bug = this.Data.Bugs.Find(id);

            if (bug == null)
            {
                return this.NotFound();
            }

            if (bugData == null)
            {
                return BadRequest("Missing bug data.");
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            if (bugData.Title != null)
            {
                bug.Title = bugData.Title;
            }

            if (bugData.Description != null)
            {
                bug.Description = bugData.Description;
            }

            if (bugData.Status != null)
            {
                BugStatus newStatus;

                if (!Enum.TryParse(bugData.Status, out newStatus))
                {
                    return this.BadRequest("Invalid bug status.");
                }

                bug.Status = newStatus;
            }

            this.Data.SaveChanges();

            return this.Ok(new
                {
                    Message = "Bug #" + id + " patched."
                }
            );
        }

        // DELETE: api/bugs/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteBug(int id)
        {
            Bug bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var commentsToDelete = this.Data.Comments.Where(c => c.Bug.Id == bug.Id);
            this.Data.Comments.RemoveRange(commentsToDelete);

            this.Data.Bugs.Remove(bug);
            this.Data.SaveChanges();

            return Ok(new
            {
                Message = "Bug #" + id + " deleted."
            });
        }

        // GET api/bugs/filter
        [HttpGet]
        [Route("filter")]
        public IHttpActionResult GetBugsByFilter([FromUri]FilterBugsBindingModel filterData)
        {
            var bugs = this.Data.Bugs.AsQueryable();

            if (filterData != null)
            {
                if (filterData.Keyword != null)
                {
                    bugs = bugs.Where(b => b.Title.Contains(filterData.Keyword));
                }

                if (filterData.Author != null)
                {
                    bugs = bugs.Where(b => b.Author.UserName == filterData.Author);
                }

                if (filterData.Statuses != null)
                {
                    var statuses = filterData.Statuses.Split('|');
                    var bugStatuses = new List<BugStatus>();

                    for (int i = 0; i < statuses.Length; i++)
                    {
                        BugStatus newStatus;

                        if (Enum.TryParse(statuses[i], out newStatus))
                        {
                            bugStatuses.Add(newStatus);
                        }
                    }

                    bugs = bugs.Where(b => bugStatuses.Contains(b.Status));
                }
            }

            var data = bugs.Select(b => new
            {
                Id = b.Id,
                Title = b.Title,
                Status = b.Status.ToString(),
                Author = b.Author != null ? b.Author.UserName : null,
                DateCreated = b.DateCreated
            });

            return this.Ok(data);
        }
    }
}