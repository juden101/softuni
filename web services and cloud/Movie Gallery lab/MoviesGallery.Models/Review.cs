using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesGallery.Models
{
    public class Review
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public Movie Movie { get; set; }

        public string Content { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
