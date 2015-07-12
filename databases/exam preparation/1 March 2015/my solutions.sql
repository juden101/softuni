-- Task 1
SELECT PeakName
FROM Peaks
ORDER BY PeakName

-- Task 2
SELECT TOP 30
	CountryName,
	Population
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY
	Population DESC,
	CountryName

-- Task 3
SELECT
	CountryName,
	CountryCode,
	(IIF(CurrencyCode = 'EUR', 'Euro', 'Not Euro')) as [Currency]
FROM Countries
ORDER BY CountryName

-- Task 4
SELECT
	CountryName as [Country Name],
	IsoCode as [ISO Code]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

-- Task 5
SELECT
	p.PeakName,
	m.MountainRange as [Mountain],
	p.Elevation
FROM Peaks p
JOIN Mountains m
	ON p.MountainId = m.Id
ORDER BY p.Elevation DESC, p.PeakName

-- Task 6
SELECT
	p.PeakName,
	m.MountainRange as [Mountain],
	c.CountryName,
	cn.ContinentName
FROM Peaks p
JOIN Mountains m
	ON p.MountainId = m.Id
JOIN MountainsCountries mc
	ON mc.MountainId = m.Id
JOIN Countries c
	ON c.CountryCode = mc.CountryCode
JOIN Continents cn
	ON cn.ContinentCode = c.ContinentCode
ORDER BY
	p.PeakName,
	c.CountryName

-- Task 7
SELECT
	r.RiverName as [River],
	COUNT(cr.CountryCode) as [Countries Count]
FROM Rivers r
JOIN CountriesRivers cr
	ON r.Id = cr.RiverId
GROUP BY r.RiverName
HAVING COUNT(cr.CountryCode) >= 3
ORDER BY r.RiverName

-- Task 8
SELECT
	MAX(Elevation) as [MaxElevation],
	MIN(Elevation) as [MinElevation],
	AVG(Elevation) as [AverageElevation]
FROM Peaks

-- Task 9
SELECT
	c.CountryName,
	cn.ContinentName,
	COUNT(r.Id) as [RiversCount],
	ISNULL(SUM(r.Length), 0) as [TotalLength]
FROM Countries c
LEFT JOIN Continents cn
	ON c.ContinentCode = cn.ContinentCode
LEFT JOIN CountriesRivers cr
	ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r
	ON r.Id = cr.RiverId
GROUP BY
	c.CountryName,
	cn.ContinentName
ORDER BY
	[RiversCount] DESC,
	[TotalLength] DESC,
	c.CountryName

-- Task 10
SELECT
	cu.CurrencyCode,
	cu.Description as [Currency],
	COUNT(c.CountryCode) as [NumberOfCountries]
FROM Currencies cu
LEFT JOIN Countries c
	ON cu.CurrencyCode = c.CurrencyCode
GROUP BY
	cu.CurrencyCode,
	cu.Description
ORDER BY
	[NumberOfCountries] DESC,
	[Currency]

-- Task 11
SELECT
	cn.ContinentName,
	SUM(c.AreaInSqKm) as [CountriesArea],
	SUM(CAST(c.Population as bigint)) as [CountriesPopulation]
FROM Continents cn
JOIN Countries c
	ON cn.ContinentCode = c.ContinentCode
GROUP BY cn.ContinentName
ORDER BY [CountriesPopulation] DESC

-- Task 12
SELECT
	c.CountryName,
	MAX(p.Elevation) as [HighestPeakElevation],
	MAX(r.Length) as [LongestRiverLength]
FROM Countries c
LEFT JOIN CountriesRivers cr
	ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r
	ON r.Id = cr.RiverId
LEFT JOIN MountainsCountries mc
	ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains m
	ON m.Id = mc.MountainId
LEFT JOIN Peaks p
	ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY
	[HighestPeakElevation] DESC,
	[LongestRiverLength] DESC,
	c.CountryName

-- Task 13
SELECT
	p.PeakName,
	r.RiverName,
	(LOWER(SUBSTRING(p.PeakName, 0, LEN(p.PeakName)) + r.RiverName)) as [Mix]
FROM Peaks p, Rivers r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY [Mix]

-- Task 14
SELECT
	c.CountryName as [Country],
	ISNULL((SELECT PeakName
		FROM Peaks
		WHERE Elevation = MAX(p.Elevation)), '(no highest peak)') as [Highest Peak Name],
	ISNULL(MAX(p.Elevation), 0) as [Highest Peak Elevation],
	ISNULL((SELECT m1.MountainRange
		FROM Mountains m1
		JOIN Peaks p1
			ON m1.Id = p1.MountainId
		WHERE p1.Elevation = MAX(p.Elevation)), '(no mountain)') as [Mountain]
FROM Countries c
LEFT JOIN MountainsCountries mc
	ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains m
	ON m.Id = mc.MountainId
LEFT JOIN Peaks p
	ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY [Country], [Highest Peak Name]

-- Task 15
BEGIN TRAN

-- 1
CREATE TABLE Monasteries(
	Id int IDENTITY NOT NULL,
	Name nvarchar(MAX) NOT NULL,
	CountryCode char(2),
	CONSTRAINT PK_Monasteries PRIMARY KEY (Id),
	FOREIGN KEY(CountryCode) REFERENCES Countries(CountryCode)
)

-- 2
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

-- 3
ALTER TABLE Countries 
ADD IsDeleted BIT NOT NULL DEFAULT 0
GO

UPDATE Countries
SET IsDeleted = 1
WHERE CountryName IN
(SELECT
	c.CountryName
FROM Countries c
JOIN CountriesRivers cr
	ON c.CountryCode = cr.CountryCode
JOIN Rivers r
	ON r.Id = cr.RiverId
GROUP BY c.CountryName
HAVING COUNT(r.Id) > 3)

SELECT
	m.Name as [Monastery],
	c.CountryName as [Country]
FROM Monasteries m
JOIN Countries c
	ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY [Monastery]

ROLLBACK TRAN

--Task 16
-- 1
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

-- 2
INSERT INTO Monasteries(Name, CountryCode)
VALUES ('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))

-- 3
INSERT INTO Monasteries(Name, CountryCode)
VALUES ('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))

-- 4
SELECT
	cn.ContinentName,
	c.CountryName,
	COUNT(m.Id) as [MonasteriesCount]
FROM Continents cn
LEFT JOIN Countries c
	ON cn.ContinentCode = c.ContinentCode
LEFT JOIN Monasteries m
	ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
GROUP BY
	cn.ContinentName,
	c.CountryName
ORDER BY
	[MonasteriesCount] DESC,
	c.CountryName

-- Task 17
CREATE PROCEDURE fn_MountainsPeaksJSON AS
	DECLARE @output NVARCHAR(MAX)
	SET @output = '{"mountains":['

	DECLARE mountainCursor CURSOR FOR
		SELECT Id, MountainRange
		FROM Mountains

	OPEN mountainCursor
		DECLARE @mountainId int
		DECLARE @mountain NVARCHAR(MAX)
		FETCH NEXT FROM mountainCursor INTO @mountainId, @mountain

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @output = @output + '{"name":"' + @mountain + '","peaks":['

			DECLARE peaksCursor CURSOR FOR
				SELECT
					p.PeakName,
					p.Elevation
				FROM Peaks p
				WHERE
					p.MountainId = @mountainId

				OPEN peaksCursor
				DECLARE @peakName NVARCHAR(MAX)
				DECLARE @elevation INT

				FETCH NEXT FROM peaksCursor
				INTO @peakName, @elevation

				WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @output = @output + '{"name":"' + @peakName + '","elevation":' + CONVERT(varchar(MAX), @elevation) + '}'

					FETCH NEXT FROM peaksCursor
					INTO @peakName, @elevation

					IF @@FETCH_STATUS = 0
						SET @output = @output + ','
				END
				CLOSE peaksCursor
				DEALLOCATE peaksCursor
			
			SET @output = @output + ']}'
			FETCH NEXT FROM mountainCursor INTO @mountainId, @mountain
			IF @@FETCH_STATUS = 0
				SET @output = @output + ','
	END
	CLOSE mountainCursor
	DEALLOCATE mountainCursor

	SET @output = @output + ']}'
	PRINT @output
GO

EXEC fn_MountainsPeaksJSON

-- Task 18
SELECT
	tc.name as `training center`,
	t.start_date as `start date`,
	c.name as `course name`,
	c.description as `more info`
FROM timetable t
JOIN training_centers tc
	ON tc.id = t.training_center_id
JOIN courses c
	ON c.id = t.course_id
ORDER BY t.start_date, t.id