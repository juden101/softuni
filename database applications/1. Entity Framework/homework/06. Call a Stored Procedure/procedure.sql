CREATE PROC usp_SelectEmployeeProjects(
	@firstName nvarchar(MAX) = '',
	@lastName nvarchar(MAX) = '')
AS
	SELECT
		p.Name,
		p.Description,
		p.StartDate
	FROM Employees e
	INNER JOIN EmployeesProjects ep
		ON e.EmployeeID = ep.EmployeeID
	INNER JOIN Projects p
		ON p.ProjectID = ep.ProjectID
	WHERE e.FirstName = @firstName AND e.LastName = @lastName
GO