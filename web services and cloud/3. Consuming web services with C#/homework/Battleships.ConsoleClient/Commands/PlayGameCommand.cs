namespace Battleships.ConsoleClient.Commands
{
    using System.Text;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Contracts;
    using System.Collections.Generic;
    using DTO;
    using Newtonsoft.Json;

    public class PlayGameCommand : AbstractCommand
    {
        private const string PlayGameEndpoint = "api/Games/Play";

        public PlayGameCommand(IBattleships battleships)
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
            string x = this.Data[2];
            string y = this.Data[3];

            var playGameTask = this.PlayGame(this.Battleships.CurrentUser.AccessToken, gameId, x, y);

            if (!playGameTask.Result.IsSuccessStatusCode)
            {
                string playGameErrorResponse = playGameTask.Result.Content.ReadAsStringAsync().Result;
                GameErrorDTO deserializedError = JsonConvert.DeserializeObject<GameErrorDTO>(playGameErrorResponse);

                throw new CommandException(string.Format("{0} {1}", Messages.InvalidPlayGame, deserializedError.Message));
            }

            StringBuilder playGameCommand = new StringBuilder();
            playGameCommand.AppendFormat(Messages.PlayGameSuccess, gameId);
            this.Battleships.Output.AppendLine(playGameCommand.ToString());
        }

        private async Task<HttpResponseMessage> PlayGame(string accessToken, string gameId, string x, string y)
        {
            using (var httpClient = new HttpClient())
            {
                string endpoint = BaseUrl + PlayGameEndpoint;

                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string> ("gameId", gameId),
                    new KeyValuePair<string, string> ("x", x),
                    new KeyValuePair<string, string> ("y", y)
                });

                var response = await httpClient.PostAsync(endpoint, content);
                return response;
            }
        }
    }
}