using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSystem.Web.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Height { get; set; }
    }
}