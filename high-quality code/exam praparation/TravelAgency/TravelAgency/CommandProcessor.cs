namespace TravelAgency
{
    using System;
    using System.Globalization;
    using TravelAgency.Utilities;

    public class CommandProcessor
    {
        public CommandProcessor(ITicketCatalog ticketCatalog)
        {
            this.TicketCatalog = ticketCatalog;
        }

        private ITicketCatalog TicketCatalog
        {
            get;
            set;
        }

        public string ProcessCommand(string line)
        {
            int firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            string command = line.Substring(0, firstSpaceIndex);
            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            string commandResult = string.Empty;
            switch (command)
            {
                case "AddAir":
                    commandResult = this.ProcessAddAirCommand(parameters);
                    break;
                case "DeleteAir":
                    commandResult = this.ProcessDeleteAirCommand(parameters);
                    break;
                case "AddTrain":
                    commandResult = this.ProcessAddTrainCommand(parameters);
                    break;
                case "DeleteTrain":
                    commandResult = this.ProcessDeleteTrainCommand(parameters);
                    break;
                case "AddBus":
                    commandResult = this.ProcessAddBusCommand(parameters);
                    break;
                case "DeleteBus":
                    commandResult = this.ProcessDeleteBusCommand(parameters);
                    break;
                case "FindTickets":
                    commandResult = this.ProcessFindTicketsCommand(parameters);
                    break;
                case "FindTicketsInInterval":
                    commandResult = this.ProcessFindTicketsInIntervalCommand(parameters);
                    break;
                default:
                    commandResult = Constants.InvalidCommand;
                    break;
            }

            return commandResult;
        }

        private static DateTime ParseDateTime(string dateTimeString)
        {
            var result = DateTime.ParseExact(dateTimeString, Constants.DateTimeFormat, CultureInfo.InvariantCulture);
            return result;
        }

        private string ProcessAddAirCommand(string[] parameters)
        {
            string flightNumber = parameters[0];
            string from = parameters[1];
            string to = parameters[2];
            string airline = parameters[3];
            DateTime dateAndTime = ParseDateTime(parameters[4]);
            decimal price = decimal.Parse(parameters[5]);

            string commandOutput = this.TicketCatalog.AddAirTicket(flightNumber, from, to, airline, dateAndTime, price);
            return commandOutput;
        }

        private string ProcessDeleteAirCommand(string[] parameters)
        {
            string flightNumber = parameters[0];

            string commandOutput = this.TicketCatalog.DeleteAirTicket(flightNumber);
            return commandOutput;
        }

        private string ProcessAddTrainCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            DateTime dateAndTime = ParseDateTime(parameters[2]);
            decimal price = decimal.Parse(parameters[3]);
            decimal studentPrice = decimal.Parse(parameters[4]);

            string commandOutput = this.TicketCatalog.AddTrainTicket(from, to, dateAndTime, price, studentPrice);
            return commandOutput;
        }

        private string ProcessDeleteTrainCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            DateTime dateAndTime = ParseDateTime(parameters[2]);

            string commandOutput = this.TicketCatalog.DeleteTrainTicket(from, to, dateAndTime);
            return commandOutput;
        }

        private string ProcessAddBusCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string busCompany = parameters[2];
            DateTime dateAndTime = ParseDateTime(parameters[3]);
            decimal price = decimal.Parse(parameters[4]);

            string commandOutput = this.TicketCatalog.AddBusTicket(from, to, busCompany, dateAndTime, price);
            return commandOutput;
        }

        private string ProcessDeleteBusCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string busCompany = parameters[2];
            DateTime dateAndTime = ParseDateTime(parameters[3]);

            string commandOutput = this.TicketCatalog.DeleteBusTicket(from, to, busCompany, dateAndTime);
            return commandOutput;
        }

        private string ProcessFindTicketsCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];

            string commandOutput = this.TicketCatalog.FindTickets(from, to);
            return commandOutput;
        }

        private string ProcessFindTicketsInIntervalCommand(string[] parameters)
        {
            DateTime startDateTime = ParseDateTime(parameters[0]);
            DateTime endDateTime = ParseDateTime(parameters[1]);

            string commandOutput = this.TicketCatalog.FindTicketsInInterval(startDateTime, endDateTime);
            return commandOutput;
        }
    }
}
