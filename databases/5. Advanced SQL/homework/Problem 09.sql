SELECT Name as Department, (SELECT AVG(Salary) FROM Employees WHERE DepartmentID = d.DepartmentID) as [Average Salary]
FROM Departments d
ORDER BY d.Name