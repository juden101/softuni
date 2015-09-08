using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using OnlineShop.Services.CustomValidation;

namespace OnlineShop.Services.Models
{
    public class CreateAdBindingModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [AdType]
        public int TypeId { get; set; }

        public decimal Price { get; set; }

        [AdCategories]
        public IEnumerable<int> Categories { get; set; }
    }
}