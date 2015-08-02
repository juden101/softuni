namespace ExportCharactersAndPlayers
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    using DiabloMappings;

    class ExportCharactersAndPlayers
    {
        static void Main()
        {
            var diabloContext = new DiabloEntities();

            var charactersAndPlayers = diabloContext.Characters
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    playedBy = c.UsersGames.Select(ug => ug.User.Username)
                });

            var charactersAndPlayersJSON = JsonConvert.SerializeObject(charactersAndPlayers, Formatting.Indented);

            File.WriteAllText("../../characters.json", charactersAndPlayersJSON);
        }
    }
}
