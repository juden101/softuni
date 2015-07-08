-- Problem 1. Create a table in SQL Server
USE [master]
GO

BEGIN TRANSACTION
	CREATE DATABASE [TestSpeed] ON  PRIMARY 
		(NAME = N'Test_Data', SIZE = 6GB, MAXSIZE = UNLIMITED, FILEGROWTH = 500MB)
		LOG ON 
		(NAME = N'Test_Log', SIZE = 2048KB, MAXSIZE = 2048GB, FILEGROWTH = 16384KB)
    GO
COMMIT

USE TestSpeed;
exec sp_spaceused

CREATE TABLE DateAndTex
(
	CurrentTime DATETIME NULL,
	TextInput NVARCHAR(MAX) NULL
)
GO

-- cost 6 secs for 10000 entities 	
-- INSERT INTO DateAndTex
-- VALUES(GETDATE(), 'put some peppers in the beans');
-- GO 10000

--costed 1 second for 10000 entities minutes on my PC.

-- costed 11 minutes and 54 seconds for 10000000 entities
BEGIN TRANSACTION
	DECLARE @counter INT = 10000000
	WHILE @counter > 0
	BEGIN
		INSERT INTO DateAndTex
		VALUES(GETDATE(), 'put some peppers in the beans'  + CAST(@counter AS NVARCHAR(15)));
		SET @counter = @counter - 1
	END
COMMIT TRANSACTION

-- befor indexing -- Get entities for first minute. Costed 8 seconds.
SELECT COUNT(r.TimeRange)
FROM (SELECT t.CurrentTime AS TimeRange
FROM DateAndTex t
WHERE t.CurrentTime 
BETWEEN CONVERT(DATETIME, '2015-08-06 20:27:35.973', 121) 
AND CONVERT(DATETIME, '2015-08-06 20:28:35.973', 121)) r

-- ready selects for checks --
-- TRUNCATE TABLE DateAndTex
-- SELECT * FROM DateAndTex
-- SELECT COUNT(TextInput) AS [Entities Count] FROM DateAndTex
-- SELECT CurrentTime, TextInput FROM DateAndTex