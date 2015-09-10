﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.RestServices.Models.BindingModels
{
    public class FilterBugsBindingModel
    {
        public string Keyword { get; set; }
        
        public string Statuses { get; set; }

        public string Author { get; set; }
    }
}