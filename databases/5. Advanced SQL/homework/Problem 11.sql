SELECT e.FirstName, e.LastName, 5 as [Employee count]
FROM Employees e
WHERE EXISTS
	 (SELECT COUNT(*) FROM Employees WHERE ManagerID = e.EmployeeID HAVING COUNT(*) = 5)
ORDER BY e.LastName