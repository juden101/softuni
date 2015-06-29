SELECT
	(e.FirstName + ' ' + e.LastName) as Employee,
	(m.FirstName + ' ' + m.LastName) as Manager
FROM Employees e
JOIN Employees m
ON (e.ManagerId = m.EmployeeId)