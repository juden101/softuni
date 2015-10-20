namespace Twitter.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTweetViewModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Content { get; set; }
    }
}