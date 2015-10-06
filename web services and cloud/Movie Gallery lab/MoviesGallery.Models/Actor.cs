﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesGallery.Models
{
    public class Actor
    {
        private ICollection<Movie> movies;

        public Actor()
        {
            this.movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BornDate { get; set; }

        public string Biography { get; set; }

        public string HomeTown { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}