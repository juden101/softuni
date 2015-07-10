-- TASK 1

SELECT PeakName
FROM Peaks
ORDER BY PeakName

-- TASK 2
SELECT TOP 30 CountryName, Population
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC

-- TASK 3
SELECT CountryName, CountryCode, (IIF(CurrencyCode = 'EUR', 'Euro', 'Not Euro')) as [Currency]
FROM Countries
ORDER BY CountryName

-- TASK 4
SELECT CountryName as [Country Name], IsoCode as [ISO Code]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

-- TASK 5
SELECT p.PeakName, m.MountainRange as [Mountain], p.Elevation
FROM Peaks p
JOIN Mountains m
	ON p.MountainId = m.Id
ORDER BY p.Elevation DESC

-- TASK 6
SELECT p.PeakName, m.MountainRange as [Mountain], c.CountryName, cn.ContinentName
FROM Peaks p
JOIN Mountains m
	ON p.MountainId = m.Id
JOIN MountainsCountries mc
	ON m.Id = mc.MountainId
JOIN Countries c
	ON c.CountryCode = mc.CountryCode
JOIN Continents cn
	ON cn.ContinentCode = c.ContinentCode
ORDER BY p.PeakName, c.CountryName

-- TASK 7
SELECT r.RiverName as [River], COUNT(*) as [Countries Count]
FROM Rivers r
JOIN CountriesRivers cr
	ON cr.RiverId = r.Id
JOIN Countries c
	ON c.CountryCode = cr.CountryCode
JOIN Continents cn
	ON cn.ContinentCode = c.ContinentCode
GROUP BY r.RiverName
HAVING COUNT(*) >= 3
ORDER BY [River]

-- TASK 8
SELECT MAX(Elevation) as [MaxElevation], MIN(Elevation) as [MinElevation], AVG(Elevation) as [AverageElevation]
FROM Peaks

-- TASK 9
SELECT c.CountryName, cn.ContinentName, COUNT(r.Id) as [RiversCount], (IIF(SUM(r.Length) > 0, SUM(r.Length), 0)) as [TotalLength]
FROM Countries c
LEFT JOIN CountriesRivers cr
	ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r
	ON r.Id = cr.RiverId
LEFT JOIN Continents cn
	ON c.ContinentCode = cn.ContinentCode
GROUP BY c.CountryName, cn.ContinentName
ORDER BY [RiversCount] DESC, [TotalLength] DESC, c.CountryName

-- TASK 10
SELECT cr.CurrencyCode, cr.Description as [Currency], COUNT(c.CountryCode) as [NumberOfCountries]
FROM Currencies cr
LEFT JOIN Countries c
	ON cr.CurrencyCode = c.CurrencyCode
GROUP BY cr.CurrencyCode, cr.Description
ORDER BY [NumberOfCountries] DESC, [Currency]

-- TASK 11
SELECT cn.ContinentName, SUM(c.AreaInSqKm) as [CountriesArea], SUM(CAST(c.Population as bigint)) as [CountriesPopulation]
FROM Continents cn
JOIN Countries c
	ON c.ContinentCode = cn.ContinentCode
GROUP BY cn.ContinentName
ORDER BY [CountriesPopulation] DESC

-- TASK 12
SELECT c.CountryName, (MAX(p.Elevation)) as [HighestPeakElevation], (MAX(r.Length)) as [LongestRiverLength]
FROM Countries c
LEFT JOIN MountainsCountries mc
	ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m
	ON m.Id = mc.MountainId
LEFT JOIN Peaks p
	ON p.MountainId = m.Id
LEFT JOIN CountriesRivers cr
	ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r
	ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.CountryName

-- TASK 13
SELECT p.PeakName, r.RiverName, (LOWER(SUBSTRING(p.PeakName, 0, LEN(p.PeakName)) + r.RiverName)) as [Mix]
FROM Peaks p, Rivers r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY [Mix]

-- TASK 14
-- first way
SELECT 
	c.CountryName AS Country,
	ISNULL((SELECT p2.PeakName FROM Peaks p2 WHERE p2.Elevation = MAX(p.Elevation)), '(no highest peak)') AS [Highest Peak Name],
	ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation],
	ISNULL((SELECT m2.MountainRange from Mountains m2 
		JOIN Peaks p3
			ON m2.Id = p3.MountainId
		WHERE p3.Elevation = max(p.Elevation)), '(no mountain)') AS Mountain
FROM Countries c
LEFT JOIN MountainsCountries mc
	ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m
	ON m.Id = mc.MountainId
LEFT JOIN Peaks p
	ON m.Id = p.MountainId
GROUP BY c.CountryName
ORDER BY Country, [Highest Peak Elevation]

-- second way
SELECT
	c.CountryName as [Country],
	p.PeakName as [Highest Peak Name],
	p.Elevation as [Highest Peak Elevation],
	m.MountainRange as [Mountain]
FROM Countries c
LEFT JOIN MountainsCountries mc
	ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m
	ON m.Id = mc.MountainId
LEFT JOIN Peaks p
	ON p.MountainId = m.Id
WHERE p.Elevation =
	(
	SELECT MAX(Elevation)
	FROM Peaks
	LEFT JOIN Mountains
		ON Peaks.MountainId = Mountains.Id
	LEFT JOIN MountainsCountries
		ON MountainsCountries.MountainId = Mountains.Id
	LEFT JOIN Countries
		ON Countries.CountryCode = MountainsCountries.CountryCode
	WHERE Countries.CountryCode = c.CountryCode
	)
UNION
SELECT
	c.CountryName as [Country],
	'(no highest peak)' as [Highest Peak Name],
	'0' as [Highest Peak Elevation],
	'(no mountain)' as [Mountain]
FROM Countries c
LEFT JOIN MountainsCountries mc
	ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m
	ON m.Id = mc.MountainId
LEFT JOIN Peaks p
	ON p.MountainId = m.Id
WHERE 
	(SELECT MAX(Elevation)
	FROM Peaks
	LEFT JOIN Mountains
		ON Peaks.MountainId = Mountains.Id
	LEFT JOIN MountainsCountries
		ON MountainsCountries.MountainId = Mountains.Id
	LEFT JOIN Countries
		ON Countries.CountryCode = MountainsCountries.CountryCode
	WHERE Countries.CountryCode = c.CountryCode) IS NULL
ORDER BY [Country], [Highest Peak Name]

-- TASK 15
CREATE TABLE Monasteries (
  Id int PRIMARY KEY IDENTITY,
  Name nvarchar(100),
  CountryCode char(2)
)

ALTER TABLE Monasteries WITH CHECK ADD CONSTRAINT FK_Monasteries_Countries
FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
GO

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

ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL
DEFAULT 0

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN
(SELECT c.CountryCode
FROM Countries c
JOIN CountriesRivers cr
	ON c.CountryCode = cr.CountryCode
JOIN Rivers r
	ON r.Id = cr.RiverId
GROUP BY c.CountryCode
HAVING COUNT(r.Id) > 3)

SELECT m.Name as [Monastery], c.CountryName as [Country]
FROM Monasteries m
JOIN Countries c
	ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY [Monastery]

-- TASK 16
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode)
VALUES
	('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania')),
	('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))

SELECT cn.ContinentName, c.CountryName, COUNT(m.Id) as [MonasteriesCount]
FROM Continents cn
LEFT JOIN Countries c
	ON c.ContinentCode = cn.ContinentCode
LEFT JOIN Monasteries m
	ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY cn.ContinentName, c.CountryName
ORDER BY [MonasteriesCount] DESC, c.CountryName

-- TASK 17
ALTER FUNCTION fn_MountainsPeaksJSON()
	RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @json NVARCHAR(MAX) = '{"mountains":['

	DECLARE montainsCursor CURSOR FOR
	SELECT Id, MountainRange FROM Mountains

	OPEN montainsCursor
	DECLARE @mountainName NVARCHAR(MAX)
	DECLARE @mountainId INT
	FETCH NEXT FROM montainsCursor INTO @mountainId, @mountainName
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @json = @json + '{"name":"' + @mountainName + '","peaks":['

		DECLARE peaksCursor CURSOR FOR
		SELECT PeakName, Elevation FROM Peaks
		WHERE MountainId = @mountainId

		OPEN peaksCursor
		DECLARE @peakName NVARCHAR(MAX)
		DECLARE @elevation INT
		FETCH NEXT FROM peaksCursor INTO @peakName, @elevation
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @json = @json + '{"name":"' + @peakName + '",' +
				'"elevation":' + CONVERT(NVARCHAR(MAX), @elevation) + '}'
			FETCH NEXT FROM peaksCursor INTO @peakName, @elevation
			IF @@FETCH_STATUS = 0
				SET @json = @json + ','
		END
		CLOSE peaksCursor
		DEALLOCATE peaksCursor
		SET @json = @json + ']}'

		FETCH NEXT FROM montainsCursor INTO @mountainId, @mountainName
		IF @@FETCH_STATUS = 0
			SET @json = @json + ','
	END
	CLOSE montainsCursor
	DEALLOCATE montainsCursor

	SET @json = @json + ']}'
	RETURN @json
END
GO

SELECT dbo.fn_MountainsPeaksJSON()