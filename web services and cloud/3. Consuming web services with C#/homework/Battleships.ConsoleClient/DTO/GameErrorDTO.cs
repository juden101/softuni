namespace Battleships.ConsoleClient.DTO
{
    using Newtonsoft.Json;

    public class GameErrorDTO
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
