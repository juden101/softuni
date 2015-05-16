namespace TravelAgency.Tickets
{
    using System;

    public class AirTicket : Ticket
    {
        public AirTicket(string flightNumber, string from, string to, string airlineCompany, DateTime dateAndTime, decimal price)
            : base(from, to, dateAndTime, price)
        {
            this.FlightNumber = flightNumber;
            this.Company = airlineCompany;
        }

        public AirTicket(string flightNumber)
            : this(flightNumber, null, null, null, default(DateTime), 0)
        {
            this.FlightNumber = flightNumber;
        }

        public override TicketType Type
        {
            get
            {
                return TicketType.Air;
            }
        }

        public string FlightNumber { get; set; }

        public string Company { get; private set; }

        public override string UniqueKey
        {
            get
            {
                string airTicketOutput = string.Format("{0};;{1}", this.Type, this.FlightNumber);

                return airTicketOutput;
            }
        }
    }
}