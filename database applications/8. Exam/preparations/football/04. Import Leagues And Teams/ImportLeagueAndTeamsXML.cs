namespace football
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class ImportLeagueAndTeamsXML
    {
        public static void Main()
        {
            var context = new FootballEntities();
            int count = 0;

            var xmlDocument = XDocument.Load("../../leagues-and-teams.xml");
            var leagueNodes = xmlDocument.XPathSelectElements("/leagues-and-teams/league");
            foreach (var leagueNode in leagueNodes)
            {
                Console.WriteLine("Processing league #{0} ...", ++count);
                League league = null;
                string leagueName = null;

                if (leagueNode.Element("league-name") != null) 
                {
                    leagueName = leagueNode.Element("league-name").Value;

                    league = context.Leagues.Where(l => l.LeagueName == leagueName).FirstOrDefault();

                    if (league == null)
                    {
                        league = new League()
                        {
                            LeagueName = leagueName
                        };
                        context.Leagues.Add(league);
                        context.SaveChanges();

                        Console.WriteLine("Created league: {0}", leagueName);
                    }
                    else
                    {
                        Console.WriteLine("Existing league: {0}", leagueName);
                    }
                }

                var matchNodes = leagueNode.XPathSelectElements("teams/team");
                foreach (var matchNode in matchNodes)
                {
                    string teamName = matchNode.Attribute("name").Value;
                    string teamCountry = null;

                    if (matchNode.Attribute("country") != null)
                    {
                        teamCountry = matchNode.Attribute("country").Value;
                    }

                    var team = context.Teams.Where(t => t.TeamName == teamName).FirstOrDefault();

                    if (team == null)
                    {
                        team = new Team()
                        {
                            TeamName = teamName,
                            CountryCode = context.Countries.Where(c => c.CountryName == teamCountry).Select(c => c.CountryCode).FirstOrDefault()
                        };

                        context.Teams.Add(team);
                        context.SaveChanges();

                        Console.WriteLine("Created team: {0} ({1})", teamName, teamCountry);
                    }
                    else
                    {
                        Console.WriteLine("Existing team: {0} ({1})", teamName, teamCountry);
                    }

                    if (leagueName != null)
                    {
                        if (league.Teams.Contains(team))
                        {
                            Console.WriteLine("Existing team in league: {0} belongs to {1}",
                                leagueName,
                                teamName);
                        }
                        else
                        {
                            team.Leagues.Add(league);
                            context.SaveChanges();

                            Console.WriteLine("Added team to league: {0} to league {1}",
                                leagueName,
                                teamName);
                        }
                    }
                }
            }
        }
    }
}