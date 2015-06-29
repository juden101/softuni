SELECT
	(FirstName + ISNULL(' ' + MiddleName + '. ', ' ') + LastName) as FullName
FROM Employees