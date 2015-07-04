SELECT d.Name as [Department], e.JobTitle as [Job Title], AVG(e.Salary) as [Average Salary]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name
ORDER BY e.JobTitle