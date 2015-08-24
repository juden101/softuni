using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Services.Models
{
    public class CreateAdBindingModel
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TypeId { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<int> Categories { get; set; }
    }
}