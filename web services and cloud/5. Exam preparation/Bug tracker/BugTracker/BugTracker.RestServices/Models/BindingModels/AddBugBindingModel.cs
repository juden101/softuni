using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.RestServices.Models.BindingModels
{
    public class AddBugBindingModel
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; }
        
        public string Description { get; set; }
    }
}