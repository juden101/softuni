namespace Movies.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public class MovieDTO
    {
        public string Isbn { get; set; }

        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }
    }
}