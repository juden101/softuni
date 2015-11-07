using Snippy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Snippy.Web.Models
{
    public class AddSnippetViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Labels { get; set; }
    }
}