namespace VehicleParkSystem
{
    using System;

    public class Engine : IEngine
    {
        public Engine(Executor executor)
        {
            this.Executor = executor;
        }

        public Engine(IUserInterface userInterface)
        {
            this.UserInterface = userInterface;
        }

        public Engine()
            : this(new Executor())
        {
        }

        private Executor Executor
        {
            get;
            set;
        }

        private IUserInterface UserInterface
        {
            get;
            set;
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();

                if (commandLine == null)
                {
                    break;
                }

                commandLine.Trim();

                // Bug fix: command was only proceeded when empty string
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        string commandResult = this.RunCommand(commandLine);
                        Console.WriteLine("{0}", commandResult);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("{0}", exception.Message);
                    }
                }
            }
        }

        public string RunCommand(string commandLine)
        {
            var command = new Command(commandLine);
            string commandResult = this.Executor.Execute(command);

            return commandResult;
        }
    }
}