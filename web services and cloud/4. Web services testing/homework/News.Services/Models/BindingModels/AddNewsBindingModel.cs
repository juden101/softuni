namespace News.Services.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddNewsBindingModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        public string Content { get; set; }
    }
}