-- Task 1
SELECT TeamName
FROM Teams
ORDER BY TeamName

-- Task 2
SELECT
	TOP 50
	CountryName,
	Population
FROM Countries
ORDER BY
	Population DESC,
	CountryName

-- Task 3
SELECT
	CountryName,
	CountryCode,
	(IIF(CurrencyCode = 'EUR', 'Inside', 'Outside')) as [Eurozone]
FROM COuntries
ORDER BY CountryName

-- Task 4
SELECT
	TeamName as [Team Name],
	CountryCode as [Country Code]
FROM Teams
WHERE TeamName LIKE '%[0-9]%'

-- Task 5
SELECT
	(SELECT CountryName
	FROM Countries
	WHERE CountryCode = im.HomeCountryCode) as [Home Team],
	(SELECT CountryName
	FROM Countries
	WHERE CountryCode = im.AwayCountryCode) as [Away Team],
	im.MatchDate as [Match Date]
FROM InternationalMatches as im
ORDER BY MatchDate DESC

-- Task 6
SELECT
	t.TeamName as [Team Name],
	l.LeagueName as [League],
	(ISNULL(c.CountryName, 'International')) as [League Country]
FROM Teams as t
JOIN Leagues_Teams as lt
	ON lt.TeamId = t.Id
JOIN Leagues as l
	ON l.Id = lt.LeagueId
LEFT JOIN Countries as c
	ON l.CountryCode = c.CountryCode
ORDER BY [Team Name], [League]

-- Task 7
SELECT
	TeamName as [Team],
	((SELECT COUNT(*) FROM TeamMatches WHERE HomeTeamId = t.Id) +
	(SELECT COUNT(*) FROM TeamMatches WHERE AwayTeamId = t.Id)) as [Matches Count]
FROM Teams as t
WHERE
	((SELECT COUNT(*) FROM TeamMatches WHERE HomeTeamId = t.Id) +
	(SELECT COUNT(*) FROM TeamMatches WHERE AwayTeamId = t.Id)) > 1
ORDER BY [Team], [Matches Count]

-- Task 8
SELECT
	l.LeagueName [League Name],
	COUNT(DISTINCT lt.TeamId) [Teams],
	COUNT(DISTINCT tm.Id) [Matches],
	ISNULL(AVG(tm.HomeGoals + tm.AwayGoals), 0) as [Average Goals]
FROM Leagues l
LEFT JOIN Leagues_Teams lt
	ON l.Id = lt.LeagueId
LEFT JOIN TeamMatches tm
	ON l.Id = tm.LeagueId
GROUP BY l.LeagueName
ORDER BY [Teams] DESC, [Matches] DESC

-- Task 9
SELECT
	t.TeamName,
	(ISNULL((SELECT SUM(tm.HomeGoals)
		FROM TeamMatches tm
		WHERE tm.HomeTeamId = t.Id), 0) +
	ISNULL((SELECT SUM(tm.AwayGoals)
		FROM TeamMatches tm
		WHERE tm.AwayTeamId = t.Id), 0)) [Total Goals]
FROM Teams t
ORDER BY [Total Goals] DESC, t.TeamName

-- Task 10
SELECT
	tm1.MatchDate [First Date],
	tm2.MatchDate [Second Date]
FROM TeamMatches tm1, TeamMatches tm2
WHERE
	tm2.MatchDate > tm1.MatchDate AND
	DATEDIFF(day, tm1.MatchDate, tm2.MatchDate) = 0
ORDER BY [First Date] DESC, [Second Date] DESC

-- Task 11
SELECT
	LOWER((LEFT(t1.TeamName, LEN(t1.TeamName) - 1) + REVERSE(t2.TeamName))) as [Mix]
FROM Teams t1, Teams t2
WHERE RIGHT(t1.TeamName, 1) = RIGHT(t2.TeamName, 1)
ORDER BY [Mix]

-- Task 12
SELECT
	c.CountryName as [Country Name],
	COUNT(DISTINCT im.Id) as [International Matches],
	COUNT(DISTINCT tm.MatchDate) as [Team Matches]
FROM Countries c
LEFT JOIN InternationalMatches im
	ON c.CountryCode = im.HomeCountryCode OR c.CountryCode = im.AwayCountryCode
LEFT JOIN Leagues l
	ON c.CountryCode = l.CountryCode
LEFT JOIN TeamMatches tm
	ON l.Id = tm.LeagueId
GROUP BY c.CountryName
HAVING COUNT(DISTINCT im.Id) > 0 OR COUNT(DISTINCT tm.MatchDate) > 0
ORDER BY
	[International Matches] DESC,
	[Team Matches] DESC,
	[Country Name]

-- Task 13
-- 1
CREATE TABLE FriendlyMatches(
	Id int IDENTITY NOT NULL,
	HomeTeamID int NOT NULL,
	AwayTeamId int NULL,
	MatchDate datetime NULL
	CONSTRAINT PK_FriendlyMatches PRIMARY KEY (Id),
	FOREIGN KEY(HomeTeamID) REFERENCES Teams(Id),
	FOREIGN KEY(AwayTeamID) REFERENCES Teams(Id)
)

-- 2
INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')

GO

-- 3
SELECT
	(SELECT TeamName
	FROM Teams
	WHERE Id = tm.HomeTeamId) as [Home Team],
	(SELECT TeamName
	FROM Teams
	WHERE Id = tm.AwayTeamId) as [Away Team],
	tm.MatchDate as [Match Date]
FROM TeamMatches tm
UNION
SELECT
	(SELECT TeamName
	FROM Teams
	WHERE Id = fm.HomeTeamId) as [Home Team],
	(SELECT TeamName
	FROM Teams
	WHERE Id = fm.AwayTeamId) as [Away Team],
	fm.MatchDate as [Match Date]
FROM FriendlyMatches fm
ORDER BY [Match Date] DESC

-- Problem 14
BEGIN TRAN

ALTER TABLE Leagues
ADD IsSeasonal BIT NOT NULL DEFAULT 0
GO

INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
VALUES ((SELECT Id FROM Teams WHERE TeamName = 'Empoli'),
	(SELECT Id FROM Teams WHERE TeamName = 'Parma'),
	2,
	2,
	'19-Apr-2015 16:00',
	(SELECT Id FROM Leagues WHERE LeagueName = 'Italian Serie A'))
	
INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
VALUES ((SELECT Id FROM Teams WHERE TeamName = 'Internazionale'),
	(SELECT Id FROM Teams WHERE TeamName = 'AC Milan'),
	0,
	0,
	'19-Apr-2015 21:45',
	(SELECT Id FROM Leagues WHERE LeagueName = 'Italian Serie A'))

UPDATE Leagues
SET IsSeasonal = 1
WHERE
Id IN
(SELECT LeagueId FROM TeamMatches)

SELECT
	(SELECT TeamName FROM Teams WHERE Id = tm.HomeTeamId) as [Home Team],
	tm.HomeGoals as [Home Goals],
	(SELECT TeamName FROM Teams WHERE Id = tm.AwayTeamId) as [Away Team],
	tm.AwayGoals as [Away Goals],
	l.LeagueName as [League Name]
FROM TeamMatches tm
LEFT JOIN Leagues l
	ON tm.LeagueId = l.Id
WHERE
	l.IsSeasonal = 1 AND
	tm.MatchDate > '10-Apr-2015'
ORDER BY
	[League Name],
	[Home Goals] DESC,
	[Away Goals] DESC

ROLLBACK TRAN

-- Problem 15
-- php version
SELECT
	t.TeamName,
	(SELECT TeamName FROM Teams WHERE Id = tm.HomeTeamId),
	(SELECT TeamName FROM Teams WHERE Id = tm.AwayTeamId),
	tm.HomeGoals,
	tm.AwayGoals,
	tm.MatchDate as [MatchDate]
FROM Teams t
LEFT JOIN TeamMatches tm
	ON t.Id = tm.HomeTeamId
WHERE t.CountryCode = 'BG'
UNION
SELECT
	t.TeamName,
	(SELECT TeamName FROM Teams WHERE Id = tm.HomeTeamId),
	(SELECT TeamName FROM Teams WHERE Id = tm.AwayTeamId),
	tm.HomeGoals,
	tm.AwayGoals,
	tm.MatchDate as [MatchDate]
FROM Teams t
LEFT JOIN TeamMatches tm
	ON t.Id = tm.AwayTeamId
WHERE t.CountryCode = 'BG'
ORDER BY t.TeamName, [MatchDate] DESC

-- procedure version
CREATE PROCEDURE fn_TeamsJSON AS
	DECLARE @output NVARCHAR(MAX)
	SET @output = '{"teams":['

	DECLARE teamsCursor CURSOR FOR
		SELECT Id, TeamName
		FROM Teams
		WHERE CountryCode = 'BG'
		ORDER BY TeamName

	OPEN teamsCursor
		DECLARE @teamId int
		DECLARE @teamName NVARCHAR(MAX)
		FETCH NEXT FROM teamsCursor INTO @teamId, @teamName

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @output = @output + '{"name":"' + @teamName + '","matches":['

			DECLARE matchesCursor CURSOR FOR
				SELECT
					(SELECT TeamName
					FROM Teams
					WHERE Id = tm.HomeTeamId) as [Home Team],
					(SELECT TeamName
					FROM Teams
					WHERE Id = tm.AwayTeamId) as [Away Team],
					tm.HomeGoals,
					tm.AwayGoals,
					CONVERT(nvarchar(max), tm.MatchDate, 103)
				FROM TeamMatches tm
				WHERE
					tm.HomeTeamId = @teamId OR
					tm.AwayTeamId = @teamId
				ORDER BY tm.MatchDate DESC

				OPEN matchesCursor
				DECLARE @homeTeam NVARCHAR(MAX)
				DECLARE @awayTeam NVARCHAR(MAX)
				DECLARE @homeGoals INT
				DECLARE @awayGoals INT
				DECLARE @matchDate NVARCHAR(MAX)

				FETCH NEXT FROM matchesCursor
				INTO @homeTeam, @awayTeam, @homeGoals, @awayGoals, @matchDate

				WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @output = @output + '{"' + @homeTeam + '":' + CONVERT(varchar(MAX), @homeGoals) + ',' +
					'"' + @awayTeam + '":' + CONVERT(varchar(MAX), @awayGoals) + ',' +
					'"date":' + @matchDate + '}'

					FETCH NEXT FROM matchesCursor INTO @homeTeam, @awayTeam, @homeGoals, @awayGoals, @matchDate
					IF @@FETCH_STATUS = 0
						SET @output = @output + ','
				END
				CLOSE matchesCursor
				DEALLOCATE matchesCursor
			
			SET @output = @output + ']}'
			FETCH NEXT FROM teamsCursor INTO @teamId, @teamName
			IF @@FETCH_STATUS = 0
				SET @output = @output + ','
	END
	CLOSE teamsCursor
	DEALLOCATE teamsCursor

	SET @output = @output + ']}'
	PRINT @output
GO

EXEC fn_TeamsJSON