namespace BookShop.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddAuthorBindingModel
    {
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}