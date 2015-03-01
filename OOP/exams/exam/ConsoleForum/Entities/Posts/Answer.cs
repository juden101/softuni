namespace ConsoleForum.Entities.Posts
{
    using System;

    using Contracts;

    public class Answer : Post, IAnswer
    {
        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }
    }
}
