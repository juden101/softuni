namespace TravelAgency.Tickets
{
    using System;
    using System.Globalization;

    using TravelAgency.Utilities;

    public abstract class Ticket : IComparable<Ticket>
    {
        protected Ticket(string from, string to, DateTime dateAndTime, decimal price)
        {
            this.From = from;
            this.To = to;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        public abstract TicketType Type { get; }

        public virtual string From { get; set; }

        public virtual string To { get; set; }

        public virtual DateTime DateAndTime { get; set; }

        public virtual decimal Price { get; set; }

        public abstract string UniqueKey { get; }

        public int CompareTo(Ticket otherTicket)
        {
            int resultOfCompare = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (resultOfCompare == 0)
            {
                resultOfCompare = ((int)this.Type).CompareTo((int)otherTicket.Type);
            }

            if (resultOfCompare == 0)
            {
                resultOfCompare = this.Price.CompareTo(otherTicket.Price);
            }

            return resultOfCompare;
        }

        public override string ToString()
        {
            string ticketOutput = string.Format(
                "[{0}; {1}; {2}]",
                this.DateAndTime.ToString(Constants.DateTimeFormat),
                this.Type.ToString().ToLower(),
                string.Format(Constants.NumberFormat, this.Price));

            return ticketOutput;
        }
    }
}