namespace Battleships.ConsoleClient.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public static class CommandFactory
    {
        private const string CommandSuffix = "Command";

        public static IExecutable Create(string commandInput, IBattleships battleships)
        {
            var data = commandInput.Split(null);
            string commandName = data[0].ToLower();

            var commandClass = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.Namespace == typeof(CommandFactory).Namespace)
                .Where(t => t.Name.EndsWith(CommandSuffix))
                .First(t => t.Name
                    .Replace(CommandSuffix, string.Empty)
                    .ToLower()
                    .Equals(commandName));

            var command = Activator.CreateInstance(commandClass, battleships) as AbstractCommand;

            foreach (var field in data)
            {
                command.Data.Add(field);
            }

            return (IExecutable)command;
        }
    }
}
