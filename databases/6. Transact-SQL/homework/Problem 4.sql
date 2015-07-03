USE Bank
GO

CREATE PROC usp_PersonsInterest(@accountId INT, @interestRate MONEY)
AS
	DECLARE @personAccountAmount MONEY
	SET @personAccountAmount = 
	(SELECT a.Balance FROM Accounts a WHERE a.PersonId = @accountId)

	DECLARE @interestCalc MONEY;
	EXEC @interestCalc = usf_CalculateInterest @sum = @personAccountAmount, @rate = @interestRate, @numberOfMonths = 1

	SELECT p.FirstName + ' ' + p.LastName AS [Person Name], @interestCalc AS [Interest Per Month] 
	FROM Persons p
	JOIN Accounts a 
	ON a.PersonID = p.PersonId
	WHERE a.PersonId = @accountId
GO

EXEC usp_PersonsInterest @accountId = 1, @interestRate = 3
GO