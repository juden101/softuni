namespace BookShop.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Purchaise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchaise { get; set; }

        [Required]
        public bool IsRecalled { get; set; }
    }
}