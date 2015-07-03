USE SoftUni
GO

 /* PROCEDURE TO ASSIGN FIrst+Last name to string searched by EmployeeID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_EmployeeFirstLastNameByID
   @employeeID INT,
   @result NVARCHAR(50) OUTPUT
AS
   SET @result = 
   (SELECT e.FirstName + ' ' + e.LastName
	FROM Employees e
	JOIN Addresses a
	ON a.AddressID = e.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
	WHERE e.EmployeeID = @employeeID)
GO
-----------------------------------------------------------

 /* PROCEDURE TO ASSIGN Name+Name to string searched by EmployeeID, EmployeeID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_ConcatenateNamesByID
   @firstEmployeeID INT,
   @secondEmployeeID INT,
   @result NVARCHAR(50) OUTPUT
AS

	DECLARE @firstEmp NVARCHAR(50)
	EXECUTE usp_EmployeeFirstLastNameByID @firstEmployeeID,  @firstEmp OUTPUT


	DECLARE @secondEmp NVARCHAR(50)
	EXECUTE usp_EmployeeFirstLastNameByID @secondEmployeeID,  @secondEmp OUTPUT

   SET @result = @firstEmp + @secondEmp
GO
-----------------------------------------------------------

 /* PROCEDURE TO ASSIGN TownID by EmployeeID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_TownIDByEmployeeID
   @EmployeeID INT,
   @result INT OUTPUT
AS 
	SET @result =
		(SELECT t.TownID 
		FROM Employees e
		JOIN Addresses a
		ON a.AddressID = e.AddressID
		JOIN Towns t
		ON t.TownID = a.TownID
		WHERE e.EmployeeID = @EmployeeID)
GO
-----------------------------------------------------------

 /* PROCEDURE Town Name By EmployeeID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_TownNameByEmployeeID
   @employeeID INT,
   @result NVARCHAR(50) OUTPUT
AS 
	SET @result =
		(SELECT t.Name
		FROM Employees e
		JOIN Addresses a
		ON a.AddressID = e.AddressID
		JOIN Towns t
		ON t.TownID = a.TownID
		WHERE e.EmployeeID = @employeeID)
GO
-----------------------------------------------------------

 /* PROCEDURE Employee First+Last Name by TownID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_EmployeesByTownID
   @TownID INT
AS 
	SELECT e.FirstName + ' ' + e.LastName
	FROM Employees e
	JOIN Addresses a
	ON a.AddressID = e.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
	WHERE t.TownID = @TownID
GO
-----------------------------------------------------------

CREATE PROCEDURE usp_ExtractEmployeesPairsByTown
AS
	SET NOCOUNT ON
	DECLARE @resultTable TABLE (Strings NVARCHAR(200))

	DECLARE employeesCursor CURSOR READ_ONLY FOR
	SELECT EmployeeID FROM Employees
	OPEN employeesCursor

	DECLARE @currentEmployeeId INT
	FETCH NEXT FROM employeesCursor 
	INTO @currentEmployeeId

		DECLARE @currentEmpTownID INT
		DECLARE @currentEmployeTownName NVARCHAR(50)
		DECLARE @employeesFromTown TABLE (EmployeeNames NVARCHAR(50))
		DECLARE @currentEmployeeNames NVARCHAR(50)

		WHILE @@FETCH_STATUS = 0
			BEGIN
		  /* UPDATE VARIABLES BLOCK */
		----------------------------------------------------------------------------------------------
				EXECUTE usp_TownIDByEmployeeID @currentEmployeeId, @currentEmpTownID OUTPUT
				EXECUTE usp_TownNameByEmployeeID @currentEmployeeId, @currentEmployeTownName OUTPUT
				INSERT INTO @employeesFromTown 
				EXECUTE usp_EmployeesByTownID @currentEmpTownID
				EXECUTE usp_EmployeeFirstLastNameByID @currentEmployeeId, @currentEmployeeNames OUTPUT
				
				INSERT INTO @resultTable
				SELECT @currentEmployeTownName + ': ' + @currentEmployeeNames + ' ' + em.EmployeeNames
				FROM @employeesFromTown	em
		----------------------------------------------------------------------------------------------

				DELETE FROM @EmployeesFromTown

			FETCH NEXT FROM employeesCursor 
			INTO @currentEmployeeId
			END
		CLOSE employeesCursor
	DEALLOCATE employeesCursor

		/* PRINT RESULT TABLE */
	------------------------------------------------------------------------
	DECLARE resultTableCursor CURSOR READ_ONLY FOR
	SELECT Strings FROM @resultTable
	OPEN resultTableCursor

	DECLARE @currentResultString NVARCHAR(200)
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
	-----------------------------------------------------------------------------------	
GO

/* EXECUTE TO OBTAIN THE RESULTS */
EXECUTE usp_ExtractEmployeesPairsByTown
GO