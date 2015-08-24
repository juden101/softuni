namespace BookShop.Services.Models
{
    using BookShop.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditCategoryBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}