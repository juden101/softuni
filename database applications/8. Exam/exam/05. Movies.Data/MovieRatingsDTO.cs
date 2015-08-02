namespace Movies.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MovieRatingsDTO
    {
        public string User { get; set; }

        public string Movie { get; set; }

        public int Rating { get; set; }
    }
}