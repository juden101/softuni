namespace Twitter.Web.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditProfileBindingModel
    {
        [Display(Name = "Avatar URL")]
        public string AvatarUrl { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        public string Biography { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }

        [Display(Name = "Birth date")]
        public DateTime? BirthDay { get; set; }
    }
}