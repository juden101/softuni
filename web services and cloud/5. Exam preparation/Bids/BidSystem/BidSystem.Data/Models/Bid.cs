using System;
using System.ComponentModel.DataAnnotations;

namespace BidSystem.Data.Models
{
    public class Bid
    {
        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public virtual User Bidder { get; set; }

        public virtual Offer Offer { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }
    }
}
