use SoftUni
GO

CREATE FUNCTION fn_FilterTownsEmployees(@filterString nvarchar(50))
RETURNS @tbl_FilteredNames TABLE
(Name NVARCHAR(50))
AS
BEGIN
	
	RETURN
END
GO

	DECLARE @filterString NVARCHAR(20)
	SET @filterString = 'oistmiahf'

	DECLARE @filterChar NCHAR
	-- extract every chracter from @filterString into table @charTable
	-- on single row. For future iterating on.
	DECLARE @charTable TABLE (Characters NCHAR)
	INSERT INTO @charTable
	SELECT SUBSTRING(a.b, v.number+1, 1) 
	FROM (SELECT @filterString b) a
	JOIN MASTER..spt_values v ON v.number < LEN(a.b)
	WHERE v.TYPE = 'P'

	-- use cursor to iterate through character rows of @charTable
	DECLARE charCursor CURSOR READ_ONLY FOR
	SELECT Characters FROM @charTable
	OPEN charCursor

	DECLARE @FilteredNames TABLE (Name NVARCHAR(50)) 
	--CREATE TABLE #FilteredNamesTwo(Name NVARCHAR(50))

	DECLARE @currentChar char(1)
	FETCH NEXT FROM charCursor 
	INTO @currentChar

	-- FirstName filter
	INSERT INTO @FilteredNames
	SELECT e.FirstName
	FROM Employees e
	WHERE e.FirstName LIKE '%['+@currentChar+']%'
	-- LastName filter
	INSERT INTO @FilteredNames
	SELECT e.LastName
	FROM Employees e
	WHERE e.LastName LIKE '%['+@currentChar+']%'
	-- Town Name filter
	INSERT INTO @FilteredNames
	SELECT t.Name
	FROM Towns t
	WHERE t.Name LIKE '%['+@currentChar+']%'  

	DECLARE @currentTableName NVARCHAR(20)
	SET @currentTableName = 'One';

	WHILE @@FETCH_STATUS = 0
	  BEGIN
			INSERT INTO @FilteredNames
			SELECT f.Name
			FROM @FilteredNames f
			WHERE f.Name LIKE '%['+@currentChar+']%'
		FETCH NEXT FROM charCursor 
		INTO @currentChar
	  END
	CLOSE charCursor
	DEALLOCATE charCursor

	SELECT * FROM @FilteredNames
GO

	
	----------------------------

	DECLARE @filterString NVARCHAR(20)
	SET @filterString = 'oistmiahf'

	-- extract every chracter from @filterString into table @charTable
	-- on single row. For future iterating on.
	DECLARE @charTable TABLE (Characters NCHAR)
	INSERT INTO @charTable
	SELECT SUBSTRING(a.b, v.number+1, 1) 
	FROM (SELECT @filterString b) a
	JOIN MASTER..spt_values v ON v.number < LEN(a.b)
	WHERE v.TYPE = 'P'

	------------------------------
	DECLARE @FilteredNames TABLE (Name NVARCHAR(50)) 

		-- FirstName filter
	INSERT INTO @FilteredNames
	SELECT e.FirstName
	FROM Employees e
	WHERE e.FirstName LIKE '%['+@filterString+']%'
	-- LastName filter
	INSERT INTO @FilteredNames
	SELECT e.LastName
	FROM Employees e
	WHERE e.LastName LIKE '%['+@filterString+']%'
	-- Town Name filter
	INSERT INTO @FilteredNames
	SELECT t.Name
	FROM Towns t
	WHERE t.Name LIKE '%['+@filterString+']%'

	-----------------------

	-- use cursor to iterate through character rows of @charTable
	DECLARE charCursor CURSOR READ_ONLY FOR
	SELECT Characters FROM @charTable
	OPEN charCursor

	DECLARE @Table1 TABLE (Name NVARCHAR(50))
	DECLARE @Table2 TABLE (Name NVARCHAR(50))

	DECLARE @currentChar char(1)
	FETCH NEXT FROM charCursor 
	INTO @currentChar

	INSERT INTO @Table1
	SELECT f.Name
	FROM @FilteredNames f
	WHERE f.Name LIKE '%'+@currentChar+'%'

	WHILE @@FETCH_STATUS = 0
	  BEGIN		

			INSERT INTO @Table2
			SELECT f.Name
			FROM @Table1 f
			WHERE f.Name LIKE '%'+@currentChar+'%'

			DELETE FROM @Table1

			INSERT INTO @Table1
			SELECT * FROM @Table2

			DELETE FROM @Table2

				SELECT * FROM @Table1
		FETCH NEXT FROM charCursor 
		INTO @currentChar
	  END
	CLOSE charCursor
	DEALLOCATE charCursor

	SELECT * FROM @Table1