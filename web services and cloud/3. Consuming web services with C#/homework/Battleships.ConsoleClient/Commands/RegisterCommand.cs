namespace Battleships.ConsoleClient.Commands
{
    using System.Collections.Generic;
    using System.Text;
    using System.Net.Http;

    using Contracts;
    using System.Threading.Tasks;

    public class RegisterCommand : AbstractCommand
    {
        private const string RegisterEndpoint = "api/Account/Register";

        public RegisterCommand(IBattleships battleships)
            : base(battleships)
        {
        }

        public override void Execute()
        {
            string email = this.Data[1];
            string password = this.Data[2];
            string confirmPassword = this.Data[3];

            Task<bool> registerTask = this.RegisterUser(email, password, confirmPassword);
            
            if (!registerTask.Result)
            {
                throw new CommandException(Messages.InvalidRegister);
            }

            StringBuilder registerCommand = new StringBuilder();
            registerCommand.AppendFormat(Messages.RegisterSuccess, email);
            this.Battleships.Output.AppendLine(registerCommand.ToString());
        }

        private async Task<bool> RegisterUser(string email, string password, string confirmPassword)
        {
            using (var httpClient = new HttpClient())
            {
                string endpoint = BaseUrl + RegisterEndpoint;

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string> ("Email", email), 
                    new KeyValuePair<string, string> ("Password", password), 
                    new KeyValuePair<string, string> ("ConfirmPassword", confirmPassword), 
                });

                var response = await httpClient.PostAsync(endpoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
