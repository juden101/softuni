SELECT TOP 1 t.Name, COUNT(*) as [Number of employees]
FROM Employees e
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [Number of employees] DESC