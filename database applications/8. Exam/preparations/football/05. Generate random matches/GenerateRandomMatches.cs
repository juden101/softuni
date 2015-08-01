namespace football
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    class GenerateRandomMatches
    {
        static void Main()
        {
            var footballContext = new FootballEntities();
            Random random = new Random();
            int count = 0;

            List<Team> allTeams = footballContext.Teams.Include("Leagues").ToList();
            List<League> allLeagues = footballContext.Leagues.ToList();

            XDocument xmlDocument = XDocument.Load("../../generate-matches.xml");
            IEnumerable<XElement> generateNodes = xmlDocument.XPathSelectElements("/generate-random-matches/generate");

            foreach (XElement generateNode in generateNodes)
            {
                Console.WriteLine("\r\nProcessing request #{0} ...", ++count);

                int generateCount = 10;
                int maxGoals = 5;
                DateTime startDate = Convert.ToDateTime("1-Jan-2000");
                DateTime endDate = Convert.ToDateTime("31-Dec-2015");
                League league = null;
                string leagueName = null;
                int? leagueId = null;

                if (generateNode.Attribute("generate-count") != null)
                {
                    generateCount = int.Parse(generateNode.Attribute("generate-count").Value);
                }

                if (generateNode.Attribute("max-goals") != null)
                {
                    maxGoals = int.Parse(generateNode.Attribute("max-goals").Value);
                }

                if (generateNode.Element("league") != null)
                {
                    leagueName = generateNode.Element("league").Value;
                    league = allLeagues.Where(l => l.LeagueName == leagueName).FirstOrDefault();

                    if (league != null)
                    {
                        leagueId = league.Id;
                    }
                }

                if (generateNode.Element("start-date") != null)
                {
                    startDate = Convert.ToDateTime(generateNode.Element("start-date").Value);
                }

                if (generateNode.Element("end-date") != null)
                {
                    endDate = Convert.ToDateTime(generateNode.Element("end-date").Value);
                }

                for (int i = 0; i < generateCount; i++)
                {
                    TimeSpan timeSpan = endDate - startDate;
                    TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
                    DateTime currentDate = startDate + newSpan;

                    var possibleTeams = allTeams;

                    if (league != null)
                    {
                        possibleTeams = possibleTeams
                            .Where(t => t.Leagues.Select(l => l.Id).Contains(league.Id))
                            .ToList();
                    }

                    var homeTeam = possibleTeams[random.Next(possibleTeams.Count())];
                    var awayTeam = possibleTeams[random.Next(possibleTeams.Count())];

                    var homeGoals = random.Next(maxGoals);
                    var awayGoals = random.Next(maxGoals);

                    TeamMatch currentTeamMatch = new TeamMatch()
                    {
                        HomeTeamId = homeTeam.Id,
                        AwayTeamId = awayTeam.Id,
                        HomeGoals = homeGoals,
                        AwayGoals = awayGoals,
                        MatchDate = currentDate,
                        LeagueId = leagueId
                    };

                    footballContext.TeamMatches.Add(currentTeamMatch);

                    Console.WriteLine("{0} {1}: - {2}: {3}-{4} ({5})",
                        currentDate.ToString("dd-MMM-yyyy"),
                        homeTeam.TeamName,
                        awayTeam.TeamName,
                        homeGoals,
                        awayGoals,
                        leagueName ?? "no league");
                }
            }

            footballContext.SaveChanges();
        }
    }
}