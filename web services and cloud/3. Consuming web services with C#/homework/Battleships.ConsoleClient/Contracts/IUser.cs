namespace Battleships.ConsoleClient.Contracts
{
    public interface IUser
    {
        string AccessToken { get; set; }

        string Email { get; set; }
    }
}