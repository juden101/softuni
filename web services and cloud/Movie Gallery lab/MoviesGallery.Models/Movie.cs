using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesGallery.Models
{
    public class Movie
    {
        private ICollection<Actor> actors;

        private ICollection<Review> reviews;

        public Movie()
        {
            this.actors = new HashSet<Actor>();
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Length { get; set; }

        [Range(0, 10)]
        public int Ration { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Actor> Actors
        {
            get { return this.actors; }
            set { this.actors = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual Genre Genre
        {
            get;
            set;
        }
    }
}
