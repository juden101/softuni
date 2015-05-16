namespace TravelAgency.Tickets
{
    using System;

    public class TrainTicket : Ticket
    {
        public TrainTicket(string from, string to, DateTime dateAndTime, decimal price = 0, decimal studentPrice = 0)
            : base(from, to, dateAndTime, price)
        {
            this.StudentPrice = studentPrice;
        }

        public decimal StudentPrice { get; set; }

        public override TicketType Type
        {
            get
            {
                return TicketType.Train;
            }
        }

        public override string UniqueKey
        {
            get
            {
                string trainTicketOutput = string.Format("{0};;{1};{2};{3};", this.Type, this.From, this.To, this.DateAndTime);
                return trainTicketOutput;
            }
        }
    }
}