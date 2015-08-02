namespace ImportUsersGames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserDTO
    {
        public UserDTO()
        {
            this.Games = new HashSet<GameDTO>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public string IpAddress { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<GameDTO> Games { get; set; }
    }
}