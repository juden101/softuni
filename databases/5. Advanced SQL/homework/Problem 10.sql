SELECT t.Name as Town, d.Name AS Department, COUNT(*) AS [Employees count]
FROM Employees e 
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY Department