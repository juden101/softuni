CREATE VIEW [Users loggeed today] AS
SELECT *
FROM Users
WHERE 
	(SELECT DATEADD(dd, DATEDIFF(dd, 0, LastLoginTime) - 3, 0)) = (SELECT DATEADD(dd, DATEDIFF(dd, 0, GETDATE()) - 3, 0))