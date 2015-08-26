namespace Battleships.ConsoleClient.Entities
{
    using Contracts;

    class User : IUser
    {
        public User(string accessToken, string email)
        {
            this.AccessToken = accessToken;
            this.Email = email;
        }

        public string AccessToken
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }
    }
}
