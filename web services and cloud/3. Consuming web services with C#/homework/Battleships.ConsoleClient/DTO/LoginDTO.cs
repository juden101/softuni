namespace Battleships.ConsoleClient.DTO
{
    using Newtonsoft.Json;

    public class LoginDTO
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("userName")]
        public string Email { get; set; }
    }
}
