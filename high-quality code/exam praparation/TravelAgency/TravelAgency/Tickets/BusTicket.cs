namespace TravelAgency.Tickets
{
    using System;

    public class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string busCompany, DateTime dateAndTime, decimal price = 0)
            : base(from, to, dateAndTime, price)
        {
            this.Company = busCompany;
        }

        public string Company
        {
            get;
            private set;
        }

        public override TicketType Type
        {
            get
            {
                return TicketType.Bus;
            }
        }

        public override string UniqueKey
        {
            get
            {
                string busTicketOutput = string.Format("{0};;{1};{2};{3}{4};", this.Type, this.From, this.To, this.Company, this.DateAndTime);
                return busTicketOutput;
            }
        }
    }
}