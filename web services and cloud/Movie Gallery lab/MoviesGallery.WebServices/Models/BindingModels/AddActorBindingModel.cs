using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesGallery.WebServices.Models.BindingModels
{
    public class AddActorBindingModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime BornDate { get; set; }

        [Required]
        public string Biography { get; set; }

        [Required]
        public string Hometown { get; set; }

        public IEnumerable<int> Movies { get; set; }
    }
}