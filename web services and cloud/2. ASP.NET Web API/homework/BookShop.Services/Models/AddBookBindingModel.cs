namespace BookShop.Services.Models
{
    using BookShop.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddBookBindingModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public BookType Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        [Required]
        public BookAgeRestriction AgeRestriction { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Categories { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}