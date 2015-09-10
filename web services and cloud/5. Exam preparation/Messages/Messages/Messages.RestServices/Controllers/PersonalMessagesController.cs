using Messages.Models;
using Messages.RestServices.Models.BindingModels;
using Messages.RestServices.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Messages.RestServices.Controllers
{
    public class PersonalMessagesController : BaseApiController
    {
        // GET api/user/personal-messages/
        [HttpGet]
        [Route("api/user/personal-messages/")]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        [Authorize]
        public IHttpActionResult GetPersonalMessages()
        {
            var userId = this.User.Identity.GetUserId();
            if (userId == null)
            {
                return this.BadRequest("Invalid session token.");
            }

            var user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var personalMessages = this.Data.UserMessages
                .All()
                .Where(um => um.Receiver.Id == user.Id)
                .OrderByDescending(um => um.DateSent)
                .Select(PersonalMessageViewModel.Create);

            return this.Ok(personalMessages);
        }

        // POST api/user/personal-messages/
        [HttpPost]
        [Route("api/user/personal-messages/")]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult AddPersonalMessage(AddPersonalMessageBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }


            var recipient = this.Data.Users.All().FirstOrDefault(u => u.UserName == model.Recipient);

            if (recipient == null)
            {
                return this.NotFound();
            }

            User user = null;
            var userId = this.User.Identity.GetUserId();

            if (userId != null)
            {
                user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);
            }

            if (user == null && userId != null)
            {
                return this.Unauthorized();
            }

            var userMessage = new UserMessage()
            {
                Text = model.Text,
                DateSent = DateTime.Now,
                Sender = user,
                Receiver = recipient
            };

            this.Data.UserMessages.Add(userMessage);
            this.Data.SaveChanges();

            if (user != null)
            {
                return this.Ok(new
                {
                    Id = userMessage.Id,
                    Sender = user.UserName,
                    Message = "Message sent to user " + recipient.UserName + "."
                });
            }

            return this.Ok(new
            {
                Id = userMessage.Id,
                Message = "Anonymous message sent to user " + recipient.UserName + "."
            });
        }
    }
}