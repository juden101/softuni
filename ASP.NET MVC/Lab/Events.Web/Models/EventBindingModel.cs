using Events.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Events.Web.Models
{
    public class EventBindingModel
    {
        [Required(ErrorMessage = "Event title is requeired.")]
        [StringLength(200, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Title *")]
        public string Title { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date and time *")]
        public DateTime StartDateTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public string Description { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        [Display(Name = "Is public?")]
        public bool IsPublic { get; set; }
    }
}