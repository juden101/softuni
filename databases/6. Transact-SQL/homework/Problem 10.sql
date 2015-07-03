USE SoftUni
GO

CREATE PROCEDURE usp_TownEmployeesList
AS
	SET NOCOUNT ON
	DECLARE @resultTable TABLE (Result NVARCHAR(MAX))
	INSERT INTO @resultTable
	SELECT t.Name + ' -> ' + dbo.StrConcat(FirstName + ' ' + LastName)
	FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
	GROUP BY t.Name

	/* PRINT RESULT TABLE */
	------------------------------------------------------------------------
	DECLARE resultTableCursor CURSOR READ_ONLY FOR
	SELECT Result FROM @resultTable
	OPEN resultTableCursor

	DECLARE @currentResultString NVARCHAR(MAX)
	FETCH NEXT FROM resultTableCursor 
	INTO @currentResultString

	WHILE @@FETCH_STATUS = 0
		BEGIN		

		PRINT @currentResultString

		FETCH NEXT FROM resultTableCursor 
		INTO @currentResultString
		END
	CLOSE resultTableCursor
	DEALLOCATE resultTableCursor
GO

EXECUTE usp_TownEmployeesList