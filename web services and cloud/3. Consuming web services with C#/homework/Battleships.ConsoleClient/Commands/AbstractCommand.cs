namespace Battleships.ConsoleClient.Commands
{
    using System.Collections.Generic;

    using Contracts;

    public abstract class AbstractCommand : ICommand
    {
        protected const string BaseUrl = "http://localhost:62859/";

        public readonly List<string> Data = new List<string>();

        protected AbstractCommand(IBattleships battleships)
        {
            this.Battleships = battleships;
        }

        public IBattleships Battleships { get; private set; }

        public abstract void Execute();
    }
}
