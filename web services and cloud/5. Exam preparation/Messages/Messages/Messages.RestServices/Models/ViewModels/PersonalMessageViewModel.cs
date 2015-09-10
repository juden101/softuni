namespace Messages.RestServices.Models.ViewModels
{
    using Messages.Models;
    using System;
    using System.Linq.Expressions;

    public class PersonalMessageViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public string Sender { get; set; }

        public static PersonalMessageViewModel Create(UserMessage personalMessage)
        {
            return new PersonalMessageViewModel
            {
                Id = personalMessage.Id,
                Text = personalMessage.Text,
                DateSent = personalMessage.DateSent,
                Sender = personalMessage.Sender != null ? personalMessage.Sender.UserName : null
            };
        }
    }
}