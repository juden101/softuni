using MoviesGallery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesGallery.WebServices.Models.BindingModels
{
    public class AddReviewBindingModel
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}