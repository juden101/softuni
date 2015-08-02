namespace ExportFinishedGames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using DiabloMappings;

    class ExportFinishedGames
    {
        static void Main()
        {
            var diabloContext = new DiabloEntities();
            var finishedGamesAndPlayers = diabloContext.Games
                .Where(g => g.IsFinished == true)
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Duration)
                .Select(g => new
                {
                    name = g.Name,
                    duration = g.Duration,
                    users = g.UsersGames.Select(ug => new
                    {
                        username = ug.User.Username,
                        ipAddress = ug.User.IpAddress
                    })
                });

            XDocument xDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));
            XElement xGames = new XElement("games");

            foreach (var match in finishedGamesAndPlayers)
            {
                XElement xGame = new XElement("game");

                xGame.Add(new XAttribute("name", match.name));

                if (match.duration != null)
                {
                    xGame.Add(new XAttribute("duration", match.duration));
                }

                XElement xUsers = new XElement("users");

                foreach (var user in match.users)
                {
                    XElement xUser = new XElement("user");
                    xUser.Add(new XAttribute("username", user.username));
                    xUser.Add(new XAttribute("ip-address", user.ipAddress));

                    xUsers.Add(xUser);
                }

                xGame.Add(xUsers);
                xGames.Add(xGame);
            }

            xDocument.Add(xGames);
            xDocument.Save("../../finished-games.xml");
        }
    }
}