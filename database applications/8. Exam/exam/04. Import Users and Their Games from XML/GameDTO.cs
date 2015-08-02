namespace ImportUsersGames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GameDTO
    {
        public string Name { get; set; }

        public CharacterDTO Character { get; set; }

        public DateTime JoinedOn { get; set; }
    }
}