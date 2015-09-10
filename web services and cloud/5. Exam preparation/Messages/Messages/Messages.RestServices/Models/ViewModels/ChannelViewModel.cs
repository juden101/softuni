namespace Messages.RestServices.Models.ViewModels
{
    using Messages.Models;
    using System;
    using System.Linq.Expressions;

    public class ChannelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static ChannelViewModel Create(Channel channel)
        {
            return new ChannelViewModel
            {
                Id = channel.Id,
                Name = channel.Name
            };
        }
    }
}