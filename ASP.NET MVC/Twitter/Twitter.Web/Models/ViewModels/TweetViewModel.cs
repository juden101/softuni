namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class TweetViewModel
    {
        public string UserName { get; set; }

        public string Content { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> Create
        {
            get
            {
                return t => new TweetViewModel()
                {
                    UserName = t.Author.UserName,
                    Content = t.Content
                };
            }
        }
    }
}