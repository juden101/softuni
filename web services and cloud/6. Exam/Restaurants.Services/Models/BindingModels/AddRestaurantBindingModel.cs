using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    public class AddRestaurantBindingModel
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        public int TownId { get; set; }
    }
}