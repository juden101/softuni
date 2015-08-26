namespace Battleships.ConsoleClient
{
    using System;
    using System.Text;

    using Contracts;
    using Commands;

    public class Battleships : IBattleships
    {
        public Battleships()
        {
            this.HasStarted = true;
            this.Output = new StringBuilder();
        }

        public bool HasStarted { get; set; }

        public bool IsLogged
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        public IUser CurrentUser { get; set; }

        public StringBuilder Output { get; private set; }

        public virtual void Run()
        {
            while (this.HasStarted)
            {
                this.ExecuteCommandLoop();
            }
        }

        protected virtual void ExecuteCommandLoop()
        {
            this.Output.Clear();
            var inputCommand = Console.ReadLine();

            try
            {
                IExecutable command = CommandFactory.Create(inputCommand, this);
                command.Execute();
            }
            catch (CommandException ex)
            {
                this.Output.AppendLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                this.Output.AppendLine(Messages.InvalidCommand);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.Output.AppendLine(Messages.InvalidCommand);
            }

            Console.Write(this.Output);
        }
    }
}
