namespace Twitter.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTweetBindingModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        [Display(Name="Tweet")]
        public string Content { get; set; }
    }
}