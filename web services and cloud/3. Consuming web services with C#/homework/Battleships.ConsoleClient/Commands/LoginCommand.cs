namespace Battleships.ConsoleClient.Commands
{
    using System.Collections.Generic;
    using System.Text;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    using Contracts;
    using DTO;
    using Entities;

    public class LoginCommand : AbstractCommand
    {
        private const string LoginEndpoint = "Token";

        public LoginCommand(IBattleships battleships)
            : base(battleships)
        {
        }

        public override void Execute()
        {
            if (this.Battleships.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            string email = this.Data[1];
            string password = this.Data[2];

            var loginTask = this.LoginUser(email, password);

            if (!loginTask.Result.IsSuccessStatusCode)
            {
                throw new CommandException(Messages.InvalidLogin);
            }

            string loginJSONResponse = loginTask.Result.Content.ReadAsStringAsync().Result;
            LoginDTO deserializedLogin = JsonConvert.DeserializeObject<LoginDTO>(loginJSONResponse);

            IUser currentUser = new User(deserializedLogin.AccessToken, deserializedLogin.Email);
            this.Battleships.CurrentUser = currentUser;

            StringBuilder loginCommand = new StringBuilder();
            loginCommand.AppendFormat(Messages.LoginSuccess, email);
            this.Battleships.Output.AppendLine(loginCommand.ToString());
        }

        private async Task<HttpResponseMessage> LoginUser(string email, string password)
        {
            using (var httpClient = new HttpClient())
            {
                string endpoint = BaseUrl + LoginEndpoint;

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string> ("Username", email),
                    new KeyValuePair<string, string> ("Password", password),
                    new KeyValuePair<string, string> ("grant_type", "password")
                });

                var response = await httpClient.PostAsync(endpoint, content);
                return response;
            }
        }
    }
}
