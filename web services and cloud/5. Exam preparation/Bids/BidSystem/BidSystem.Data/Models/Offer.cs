﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BidSystem.Data.Models
{
    public class Offer
    {
        private ICollection<Bid> bids;

        public Offer()
        {
            this.bids = new HashSet<Bid>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }

        public virtual User Seller { get; set; }

        public DateTime PublishDate { get; set; }

        public decimal InitialPrice { get; set; }

        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<Bid> Bids
        {
            get { return this.bids; }
            set { this.bids = value; }
        }
    }
}
