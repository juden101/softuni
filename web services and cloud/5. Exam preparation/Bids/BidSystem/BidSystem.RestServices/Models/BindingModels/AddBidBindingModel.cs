using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BidSystem.RestServices.Models.BindingModels
{
    public class AddBidBindingModel
    {
        [Required]
        public decimal BidPrice { get; set; }
        
        public string Comment { get; set; }
    }
}