using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    public class AddOrderBindingModel
    {
        [Required]
        public int Quantity { get; set; }
    }
}