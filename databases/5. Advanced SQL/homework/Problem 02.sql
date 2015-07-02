SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary < (SELECT (MIN(Salary) + (MIN(Salary) * 0.1)) FROM Employees)