namespace football
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    class ExportInternationalMatches
    {
        static void Main()
        {
            var footballEntities = new FootballEntities();
            var internationalMatches = footballEntities.InternationalMatches
                .OrderBy(im => im.MatchDate)
                .ThenBy(im => im.HomeCountry.CountryName)
                .ThenBy(im => im.AwayCountry.CountryName)
                .Select(im => new
                {
                    homeCountryCode = im.HomeCountryCode,
                    homeCountryName = im.HomeCountry.CountryName,
                    awayCountryCode = im.AwayCountryCode,
                    awayCountryName = im.AwayCountry.CountryName,
                    dateTime = im.MatchDate,
                    homeScore = im.HomeGoals,
                    awayScore = im.AwayGoals,
                    leagueName = im.League.LeagueName
                })
                .ToList();

            var document = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));
            XElement matches = new XElement("matches");

            foreach (var internationalMatch in internationalMatches)
            {
                var match = new XElement("match");

                if (internationalMatch.dateTime != null)
                {
                    if (internationalMatch.dateTime.Value.TimeOfDay.TotalMilliseconds == 0) 
                    {
                        var dateAttribute = new XAttribute("date", internationalMatch.dateTime.Value.ToString("dd-MM-yyyy"));
                        match.Add(dateAttribute);
                    }
                    else
                    {
                        var datetimeAttribute = new XAttribute("datetime", internationalMatch.dateTime.Value.ToString("dd-MM-yyyy HH:mm:ff"));
                        match.Add(datetimeAttribute);
                    }
                }

                var homeCountry = new XElement("home-country");
                homeCountry.Add(new XAttribute("code", internationalMatch.homeCountryCode));
                homeCountry.Value = internationalMatch.homeCountryName;
                match.Add(homeCountry);

                var awayCountry = new XElement("away-country");
                awayCountry.Add(new XAttribute("code", internationalMatch.awayCountryCode));
                awayCountry.Value = internationalMatch.awayCountryName;
                match.Add(awayCountry);

                if (internationalMatch.homeScore != null && internationalMatch.awayScore != null)
                {
                    var score = new XElement("score");
                    score.Value = string.Format("{0}:{1}",
                        internationalMatch.homeScore,
                        internationalMatch.awayScore);

                    match.Add(score);
                }

                if (internationalMatch.leagueName != null)
                {
                    var league = new XElement("league");
                    league.Value = string.Format("{0}", internationalMatch.leagueName);

                    match.Add(league);
                }

                matches.Add(match);
            }

            document.Add(matches);
            document.Save("../../international-matches.xml");
        }
    }
}