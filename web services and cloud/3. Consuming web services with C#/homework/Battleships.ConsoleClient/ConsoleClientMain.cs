namespace Battleships.ConsoleClient
{
    using Contracts;

    public class ConsoleClientMain
    {
        static void Main()
        {
            // commands:
            // register {email} {password} {confirmPassword}
            // login {email} {password}
            // createGame
            // joinGame {gameId}
            // play {gameId} {x} {y}

            IBattleships battleships = new Battleships();
            battleships.Run();
        }
    }
}