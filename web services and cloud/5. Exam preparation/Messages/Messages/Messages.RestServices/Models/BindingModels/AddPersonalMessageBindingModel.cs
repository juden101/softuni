using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Messages.RestServices.Models.BindingModels
{
    public class AddPersonalMessageBindingModel
    {
        [Required]
        [MinLength(1)]
        public string Text { get; set; }

        [Required]
        [MinLength(1)]
        public string Recipient { get; set; }
    }
}