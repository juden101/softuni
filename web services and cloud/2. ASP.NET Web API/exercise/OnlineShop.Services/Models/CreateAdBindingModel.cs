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

        [Required]
        public int TypeId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public IEnumerable<int> Categories { get; set; }
    }
}