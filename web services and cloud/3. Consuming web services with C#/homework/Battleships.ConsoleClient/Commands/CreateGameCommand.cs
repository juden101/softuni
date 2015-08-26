namespace Battleships.ConsoleClient.Commands
{
    using System.Text;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Contracts;

    public class CreateGameCommand : AbstractCommand
    {
        private const string CreateGameEndpoint = "api/Games/Create";

        public CreateGameCommand(IBattleships battleships)
            : base(battleships)
        {
        }

        public override void Execute()
        {
            if (!this.Battleships.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            
            var createGameTask = this.CreateGame(this.Battleships.CurrentUser.AccessToken);

            if (!createGameTask.Result.IsSuccessStatusCode)
            {
                throw new CommandException(Messages.InvalidCreateGame);
            }

            string gameId = createGameTask.Result.Content.ReadAsStringAsync().Result.Replace("\"", "");

            StringBuilder createGameCommand = new StringBuilder();
            createGameCommand.AppendFormat(Messages.CreateGameSuccess, gameId);
            this.Battleships.Output.AppendLine(createGameCommand.ToString());
        }

        private async Task<HttpResponseMessage> CreateGame(string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                string endpoint = BaseUrl + CreateGameEndpoint;

                httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

                var response = await httpClient.PostAsync(endpoint, null);
                return response;
            }
        }
    }
}
