namespace Battleships.ConsoleClient.Commands
{
    using System.Text;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Contracts;
    using System.Collections.Generic;
    using DTO;
    using Newtonsoft.Json;

    public class JoinGameCommand : AbstractCommand
    {
        private const string JoinGameEndpoint = "api/Games/Join";

        public JoinGameCommand(IBattleships battleships)
            : base(battleships)
        {
        }

        public override void Execute()
        {
            if (!this.Battleships.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            string gameId = this.Data[1];
            var joinGameTask = this.JoinGame(this.Battleships.CurrentUser.AccessToken, gameId);

            if (!joinGameTask.Result.IsSuccessStatusCode)
            {
                string joinGameErrorResponse = joinGameTask.Result.Content.ReadAsStringAsync().Result;
                GameErrorDTO deserializedError = JsonConvert.DeserializeObject<GameErrorDTO>(joinGameErrorResponse);

                throw new CommandException(string.Format("{0} {1}", Messages.InvalidJoinGame, deserializedError.Message));
            }

            StringBuilder joinGameCommand = new StringBuilder();
            joinGameCommand.AppendFormat(Messages.JoinGameSuccess, gameId);
            this.Battleships.Output.AppendLine(joinGameCommand.ToString());
        }

        private async Task<HttpResponseMessage> JoinGame(string accessToken, string gameId)
        {
            using (var httpClient = new HttpClient())
            {
                string endpoint = BaseUrl + JoinGameEndpoint;

                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string> ("gameId", gameId)
                });

                var response = await httpClient.PostAsync(endpoint, content);
                return response;
            }
        }
    }
}
