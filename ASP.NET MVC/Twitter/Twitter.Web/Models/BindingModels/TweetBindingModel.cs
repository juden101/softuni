namespace Twitter.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class TweetBindingModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Content { get; set; }
    }
}