using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportSystem.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateAndTime { get; set; }
        
        public string Author { get; set; }
    }
}