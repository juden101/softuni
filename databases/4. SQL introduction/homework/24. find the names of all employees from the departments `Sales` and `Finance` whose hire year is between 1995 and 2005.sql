SELECT FirstName, LastName, MiddleName
FROM Employees as e
JOIN Departments as d
ON (e.DepartmentID = d.DepartmentID)
WHERE 
	(d.Name = 'Sales' OR d.Name = 'Finance') AND
	YEAR(e.HireDate) BETWEEN '1995' AND '2005'