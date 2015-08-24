namespace BookShop.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BookSearchBindingModel
    {
        [Required]
        public string Search { get; set; }
    }
}