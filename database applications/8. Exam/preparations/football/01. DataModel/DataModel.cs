namespace football
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DataModel
    {
        static void Main()
        {
            var footballEntities = new FootballEntities();
            var footballTeams = footballEntities.Teams
                .Select(t => t.TeamName);

            foreach (var footballTeam in footballTeams)
            {
                Console.WriteLine(footballTeam);
            }
        }
    }
}