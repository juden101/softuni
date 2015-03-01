namespace ConsoleForum.Entities.Posts
{
    using Contracts;
    using Entities;

    public abstract class Post : IPost
    {
        private int id;
        private string body;
        private IUser author;

        protected Post(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                Validator.NotNegativeNumber(value);
                this.id = value;
            }
        }

        public string Body
        {
            get
            {
                return this.body;
            }
            set
            {
                Validator.NotEmptyString(value);
                this.body = value;
            }
        }

        public IUser Author
        {
            get
            {
                return this.author;
            }
            set
            {
                this.author = value;
            }
        }
    }
}
