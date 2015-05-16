namespace TravelAgency
{
    using System;
    using System.Globalization;

    using TravelAgency.Utilities;

    public class TravelAgencyMain
    {
        public static void Main()
        {
            ITicketCatalog ticketCatalog = new TicketCatalog();
            CommandProcessor commandProcessor = new CommandProcessor(ticketCatalog);

            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                if (line != string.Empty)
                {
                    string commandResult = commandProcessor.ProcessCommand(line);
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}