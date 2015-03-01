namespace ConsoleForum.Entities.Users
{
    using System;
    using System.Collections.Generic;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities;

    public class User : IUser
    {
        private int id;
        private string name;
        private string password;
        private string email;
        private IList<IQuestion> questions;

        public User(int id, string name, string password, string email)
        {
            this.Id = id;
            this.Username = name;
            this.Password = password;
            this.Email = email;
            this.Questions = new List<IQuestion>();
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

        public string Username
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.NotEmptyString(value);
                this.name = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                Validator.NotEmptyString(value);
                this.password = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                Validator.NotEmptyString(value);
                this.email = value;
            }
        }

        public IList<IQuestion> Questions
        {
            get
            {
                return this.questions;
            }
            set
            {
                this.questions = value;
            }
        }
    }
}
