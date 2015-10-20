namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class UserTweetViewModel
    {
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserFullName { get; set; }

        public string UserAvatarUrl { get; set; }

        public int? LikesCount { get; set; }

        public int? RetweetsCount { get; set; }

        public int? FollowersCount { get; set; }

        public int? FollowingCount { get; set; }

        public int? FavouritesCount { get; set; }

        public static Expression<Func<Tweet, UserTweetViewModel>> Create
        {
            get
            {
                return tweet => new UserTweetViewModel()
                {
                    Content = tweet.Content,
                    CreatedAt = tweet.CreatedAt,
                    UserFullName = tweet.Author.FullName,
                    UserAvatarUrl = tweet.Author.AvatarUrl,
                    LikesCount = tweet.Likes.Count,
                    RetweetsCount = tweet.Retweets.Count,
                    FollowersCount = tweet.Author.FollowersUsers.Count,
                    FollowingCount = tweet.Author.FollowingUsers.Count,
                    FavouritesCount = tweet.Author.FavouriteTweets.Count
                };
            }
        }
    }
}