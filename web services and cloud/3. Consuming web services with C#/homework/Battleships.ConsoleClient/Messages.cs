namespace Battleships.ConsoleClient
{
    public static class Messages
    {
        public const string InvalidCommand = "Invalid command!";
        public const string InvalidRegister = "Invalid register!";
        public const string InvalidLogin = "Invalid login!";
        public const string InvalidCreateGame = "Invalid game creation!";
        public const string InvalidJoinGame = "Invalid game join!";
        public const string InvalidPlayGame = "Invalid game play!";
        public const string AlreadyLoggedIn = "Already logged in.";
        public const string NotLogged = "Operation not permitted. You have to login first";

        public const string RegisterSuccess = "{0} successfully registered";
        public const string LoginSuccess = "{0} successfully logged in";
        public const string CreateGameSuccess = "Game {0} successfully created";
        public const string JoinGameSuccess = "Game {0} successfully joined";
        public const string PlayGameSuccess = "Game move successfully played";
    }
}