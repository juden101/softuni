namespace Messages.RestServices.Models.ViewModels
{
    using Messages.Models;
    using System;
    using System.Linq.Expressions;

    public class ChannelMessageViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public string Sender { get; set; }

        public static ChannelMessageViewModel Create(ChannelMessage channelMessage)
        {
            return new ChannelMessageViewModel
            {
                Id = channelMessage.Id,
                Text = channelMessage.Text,
                DateSent = channelMessage.DateSent,
                Sender = channelMessage.Sender != null ? channelMessage.Sender.UserName : null
            };
        }
    }
}