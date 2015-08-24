namespace BookShop.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddCategoryBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}