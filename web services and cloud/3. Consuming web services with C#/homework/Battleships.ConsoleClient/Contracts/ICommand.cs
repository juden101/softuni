namespace Battleships.ConsoleClient.Contracts
{
    public interface ICommand : IExecutable
    {
        IBattleships Battleships { get; }
    }
}
