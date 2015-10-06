using MoviesGallery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesGallery.WebServices.Models.BindingModels
{
    public class AddMovieBindingModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public int Length { get; set; }

        [Required]
        [Range(0, 10)]
        public int Ration { get; set; }

        [Required]
        public string Country { get; set; }

        public IEnumerable<int> Actors { get; set; }

        public IEnumerable<int> Reviews { get; set; }

        public int Genre { get; set; }
    }
}