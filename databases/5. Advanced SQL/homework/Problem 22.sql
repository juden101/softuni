INSERT INTO Users(Username, Password, FullName)
	SELECT 
		LOWER(SUBSTRING(FirstName, 1, 1) + LastName) + CONVERT(nvarchar(10), EmployeeID),
		LOWER(SUBSTRING(FirstName, 1, 1) + LastName),
		(FirstName + ' ' + LastName)
	FROM Employees