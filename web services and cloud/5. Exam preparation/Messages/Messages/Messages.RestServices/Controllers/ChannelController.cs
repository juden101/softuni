using Messages.Models;
using Messages.RestServices.Models.BindingModels;
using Messages.RestServices.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Messages.RestServices.Controllers
{
    public class ChannelController : BaseApiController
    {
        // GET api/channels
        [HttpGet]
        [Route("api/channels")]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetAllChannels()
        {
            var data = this.Data.Channels
                .OrderBy(c => c.Name)
                .Select(ChannelViewModel.Create);

            return this.Ok(data);
        }

        // GET api/channels/{id}
        [HttpGet]
        [Route("api/channels/{id}")]
        [ResponseType(typeof(IQueryable<IHttpActionResult>))]
        public IHttpActionResult GetChannel(int id)
        {
            var channel = this.Data.Channels.Where(c => c.Id == id);

            if (!channel.Any())
            {
                return this.NotFound();
            }

            var data = channel
                .Select(ChannelViewModel.Create);

            return this.Ok(data.FirstOrDefault());
        }

        // POST api/channels
        [HttpPost]
        [Route("api/channels")]
        public IHttpActionResult AddChannel([FromBody]AddChannelBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.Data.Channels.Any(c => c.Name == model.Name))
            {
                return this.Conflict();
            }

            var channel = new Channel()
            {
                Name = model.Name
            };

            this.Data.Channels.Add(channel);
            this.Data.SaveChanges();

            var result = this.Data.Channels
                .Where(c => c.Id == channel.Id)
                .Select(ChannelViewModel.Create);

            return this.Created("api/channels/" + channel.Id, result.FirstOrDefault());
        }

        // PUT api/channels
        [HttpPut]
        [Route("api/channels/{id}")]
        public IHttpActionResult EditChannel(int id, [FromBody]EditChannelBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var channel = this.Data.Channels.FirstOrDefault(c => c.Id == id);

            if (channel == null)
            {
                return this.NotFound();
            }

            if (this.Data.Channels.Any(c => c.Name == model.Name))
            {
                return this.Conflict();
            }

            channel.Name = model.Name;
            this.Data.SaveChanges();

            var result = this.Data.Channels
                .Where(c => c.Id == channel.Id)
                .Select(ChannelViewModel.Create);

            return this.Ok(result);
        }

        // DELETE api/channels/{id}
        [Route("api/channels/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteChannel(int id)
        {
            var channel = this.Data.Channels.FirstOrDefault(c => c.Id == id);

            if (channel == null)
            {
                return this.NotFound();
            }

            if (channel.ChannelMessages.Any())
            {
                return this.Conflict();
            }

            this.Data.Channels.Remove(channel);
            this.Data.SaveChanges();

            return this.Ok(new
            {
                Message = string.Format("Channel #{0} deleted.", id)
            });
        }
    }
}