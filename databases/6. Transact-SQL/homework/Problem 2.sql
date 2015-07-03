USE Bank
GO

CREATE PROC usp_SelectPersonsByMinimalBalance(@minBalance int = 0)
AS
	SELECT *
	FROM Persons p
	JOIN Accounts a
		ON p.PersonId = a.PersonId
	WHERE a.Balance >= @minBalance
GO

EXEC usp_SelectPersonsByMinimalBalance 100