namespace Battleships.ConsoleClient.Commands
{
    using Contracts;

    public class ExitCommand : AbstractCommand
    {
        public ExitCommand(IBattleships battleships)
            : base(battleships)
        {
        }

        public override void Execute()
        {
            this.Battleships.HasStarted = false;
        }
    }
}