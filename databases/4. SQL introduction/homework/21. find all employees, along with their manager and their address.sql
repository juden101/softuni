SELECT
	(e.FirstName + ' ' + e.LastName) as Employee,
	(m.FirstName + ' ' + m.LastName) as Manager,
	a.AddressText as EmployeeAddress
FROM Employees e
JOIN Employees m ON (e.ManagerId = m.EmployeeId)
JOIN Addresses a ON (e.AddressID = a.AddressID)