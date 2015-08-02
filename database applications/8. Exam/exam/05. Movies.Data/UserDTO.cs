namespace Movies.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserDTO
    {
        public string Username { get; set; }

        public int? Age { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }
    }
}