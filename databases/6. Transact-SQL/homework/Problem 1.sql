USE Bank
GO

CREATE PROC usp_SelectNamesOfAllPersons
AS
	SELECT (FirstName + ' ' + LastName) as FullName
	FROM Persons
GO

EXEC usp_SelectNamesOfAllPersons