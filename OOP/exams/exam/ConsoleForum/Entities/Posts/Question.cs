namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Entities;

    public class Question : Post, IQuestion
    {
        private string title;
        private IList<IAnswer> answers;

        public Question(int id, string body, IUser author, string title, IList<IAnswer> answers)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = answers;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                Validator.NotEmptyString(value);
                this.title = value;
            }
        }

        public IList<IAnswer> Answers
        {
            get
            {
                return this.answers;
            }
            private set
            {
                this.answers = value;
            }
        }
    }
}
