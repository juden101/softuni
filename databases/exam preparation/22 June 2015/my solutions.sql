/*
-- 1
SELECT TeamName
FROM Teams

-- 2
SELECT TOP 50 CountryName, Population
FROM Countries
ORDER BY Population DESC, CountryName

-- 3
SELECT CountryName, CountryCode, IIF(CurrencyCode = 'EUR', 'Inside', 'Outside') as [Eurozone]
FROM Countries
ORDER BY CountryName

-- 4
SELECT TeamName as [Team Name], CountryCode as [Country Code]
FROM Teams
WHERE TeamName LIKE '%[0-9]%'
ORDER BY CountryCode

-- 5
SELECT
	(SELECT CountryName FROM Countries WHERE CountryCode = HomeCountryCode) as [Home Team],
	(SELECT CountryName FROM Countries WHERE CountryCode = AwayCountryCode) as [Away Team],
	MatchDate as [Match Date]
FROM InternationalMatches
ORDER BY MatchDate DESC

-- 6
SELECT
	t.TeamName as [Team Name],
	l.LeagueName as [League],
	IIF(c.CountryName IS NOT NULL, c.CountryName, 'International') as [League Country]
FROM Teams t
JOIN Leagues_Teams lt
	ON t.Id = lt.TeamId
JOIN Leagues l
	ON l.Id = lt.LeagueId
LEFT JOIN Countries c
	ON l.CountryCode = c.CountryCode
ORDER BY [Team Name], [League]

-- 7
SELECT TeamName as [Team], 
	(SELECT COUNT(DISTINCT tm.Id)
	FROM TeamMatches tm
	WHERE tm.HomeTeamId = t.Id OR tm.AwayTeamId = t.Id) as [Matches Count]
FROM Teams t
WHERE (SELECT COUNT(DISTINCT tm.Id)
	FROM TeamMatches tm
	WHERE tm.HomeTeamId = t.Id OR tm.AwayTeamId = t.Id) > 1
ORDER BY [Team]
*/
-- 8
