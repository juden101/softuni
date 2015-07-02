SELECT (FirstName + ' ' + LastName) as FullName, Salary, Name as Department
FROM Employees e
JOIN Departments d
On e.DepartmentID = d.DepartmentID
WHERE Salary = (SELECT MIN(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID)