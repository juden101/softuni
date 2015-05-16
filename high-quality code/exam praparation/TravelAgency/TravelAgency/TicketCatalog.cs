namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TravelAgency.Tickets;
    using TravelAgency.Utilities;

    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private Dictionary<string, Ticket> ticketsByUniqueKey = new Dictionary<string, Ticket>();
        private MultiDictionary<string, Ticket> ticketsFromTo = new MultiDictionary<string, Ticket>(true);
        private OrderedMultiDictionary<DateTime, Ticket> ticketsByDate = new OrderedMultiDictionary<DateTime, Ticket>(true);
        private Dictionary<TicketType, int> ticketCountByType = new Dictionary<TicketType, int>();

        public TicketCatalog()
        {
            this.ticketCountByType[TicketType.Air] = 0;
            this.ticketCountByType[TicketType.Bus] = 0;
            this.ticketCountByType[TicketType.Train] = 0;
        }

        public int GetTicketsCount(TicketType type)
        {
            return this.ticketCountByType[type];
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateAndTime, decimal price)
        {
            AirTicket ticket = new AirTicket(flightNumber, from, to, airline, dateAndTime, price);
            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            AirTicket ticket = new AirTicket(flightNumber);
            string result = this.DeleteTicketByUniqueKey(ticket.UniqueKey);

            return result;
        }

        public string AddTrainTicket(string from, string to, DateTime dateAndTime, decimal price, decimal studentPrice)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateAndTime, price, studentPrice);
            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateAndTime)
        {
            TrainTicket ticket = new TrainTicket(from, to, dateAndTime);
            string result = this.DeleteTicketByUniqueKey(ticket.UniqueKey);

            return result;
        }

        public string AddBusTicket(string from, string to, string busCompany, DateTime dateAndTime, decimal price)
        {
            BusTicket ticket = new BusTicket(from, to, busCompany, dateAndTime, price);
            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteBusTicket(string from, string to, string busCompany, DateTime dateAndTime)
        {
            BusTicket ticket = new BusTicket(from, to, busCompany, dateAndTime);
            string result = this.DeleteTicketByUniqueKey(ticket.UniqueKey);

            return result;
        }

        public string FindTickets(string from, string to)
        {
            string fromToKey = CreateFromToKey(from, to);

            if (this.ticketsFromTo.ContainsKey(fromToKey))
            {
                var ticketsFound = this.ticketsFromTo[fromToKey];
                string ticketsAsString = FormatTicketsForPrinting(ticketsFound);

                return ticketsAsString;
            }

            return Constants.NotFoundMessage;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.ticketsByDate.Range(startDateTime, true, endDateTime, true).Values;

            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = FormatTicketsForPrinting(ticketsFound);

                return ticketsAsString;
            }

            return Constants.NotFoundMessage;
        }

        private static string CreateFromToKey(string from, string to)
        {
            return from + "; " + to;
        }

        private static string FormatTicketsForPrinting(IEnumerable<Ticket> tickets)
        {
            string ticketsOutput = string.Join(" ", tickets.OrderBy(t => t));

            return ticketsOutput;
        }

        private string AddTicket(Ticket ticket)
        {
            string key = ticket.UniqueKey;
            if (this.ticketsByUniqueKey.ContainsKey(key))
            {
                return Constants.DuplicateTicketMessage;
            }

            string fromToKey = CreateFromToKey(ticket.From, ticket.To);

            this.ticketsByUniqueKey.Add(key, ticket);
            this.ticketsFromTo.Add(fromToKey, ticket);
            this.ticketsByDate.Add(ticket.DateAndTime, ticket);
            this.ticketCountByType[ticket.Type]++;

            return Constants.TicketAddedMessage;
        }

        private string DeleteTicketByUniqueKey(string uniqueKey)
        {
            if (this.ticketsByUniqueKey.ContainsKey(uniqueKey))
            {
                var ticket = this.ticketsByUniqueKey[uniqueKey];
                string fromToKey = CreateFromToKey(ticket.From, ticket.To);

                this.ticketsByUniqueKey.Remove(uniqueKey);
                this.ticketsFromTo.Remove(fromToKey, ticket);
                this.ticketsByDate.Remove(ticket.DateAndTime, ticket);
                this.ticketCountByType[ticket.Type]--;

                return Constants.TicketDeletedMessage;
            }

            return Constants.TicketDoesNotExistMessage;
        }
    }
}