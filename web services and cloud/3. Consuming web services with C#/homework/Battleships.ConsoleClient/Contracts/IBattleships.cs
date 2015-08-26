namespace Battleships.ConsoleClient.Contracts
{
    using System.Text;

    public interface IBattleships
    {
        bool HasStarted { get; set; }

        bool IsLogged { get; }

        IUser CurrentUser { get; set; }

        StringBuilder Output { get; }

        void Run();
    }
}