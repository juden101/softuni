namespace football
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class ExportLeaguesAndTeams
    {
        static void Main()
        {
            var footballEntities = new FootballEntities();
            var leaguesWithTeams = footballEntities.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName)
                });

            var leaguesWithTeamsJson = JsonConvert.SerializeObject(leaguesWithTeams, Formatting.Indented);

            File.WriteAllText("../../leagues-and-teams.json", leaguesWithTeamsJson);
        }
    }
}