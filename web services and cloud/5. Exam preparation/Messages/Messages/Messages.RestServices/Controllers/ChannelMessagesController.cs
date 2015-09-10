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
    public class ChannelMessagesController : BaseApiController
    {
        // GET api/channel-messages/{channelName}
        [HttpGet]
        [Route("api/channel-messages/{channelName}")]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetChannelMessages(string channelName)
        {
            var channel = this.Data.Channels
                .FirstOrDefault(c => c.Name == channelName);

            if (channel == null)
            {
                return this.NotFound();
            }

            var data = channel.ChannelMessages
                .OrderByDescending(cm => cm.DateSent)
                .Select(ChannelMessageViewModel.Create);

            return this.Ok(data);
        }

        // GET api/channel-messages/{channelName}?limit={limit}
        [HttpGet]
        [Route("api/channel-messages/{channelName}")]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetChannelMessages(string channelName, int limit)
        {
            var channel = this.Data.Channels
                .FirstOrDefault(c => c.Name == channelName);

            if (channel == null)
            {
                return this.NotFound();
            }

            if (limit < 1 || limit > 1000)
            {
                return this.BadRequest();
            }

            var data = channel.ChannelMessages
                .Take(limit)
                .Select(ChannelMessageViewModel.Create);

            return this.Ok(data);
        }
        
        // POST api/channel-messages/{channelName}
        [HttpPost]
        [Route("api/channel-messages/{channelName}")]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult AddChannelMessage(string channelName, AddChannelMessageBindingModel model)
        {
            var channel = this.Data.Channels
                .FirstOrDefault(c => c.Name == channelName);

            if (channel == null)
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

            User user = null;
            var userId = this.User.Identity.GetUserId();

            if (userId != null)
            {
                user = this.Data.Users.FirstOrDefault(u => u.Id == userId);
            }

            if (user == null && userId != null)
            {
                return this.Unauthorized();
            }
            
            var channelMessage = new ChannelMessage()
            {
                Text = model.Text,
                DateSent = DateTime.Now,
                Sender = user
            };

            channel.ChannelMessages.Add(channelMessage);
            this.Data.SaveChanges();

            if (user != null)
            {
                return this.Ok(new
                {
                    Id = channelMessage.Id,
                    Sender = user.UserName,
                    Message = "Message sent to channel " + channel.Name + "."
                });
            }

            return this.Ok(new
            {
                Id = channelMessage.Id,
                Message = "Anonymous message sent to channel " + channel.Name + "."
            });
        }
    }
}