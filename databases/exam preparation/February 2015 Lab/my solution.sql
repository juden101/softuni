-- Task 1
SELECT Title
FROM Questions
ORDER BY Title

--Task 2
SELECT Content, CreatedOn
FROM Answers
WHERE CreatedOn BETWEEN '2012/06/15' AND '2013/03/22'
ORDER BY CreatedOn, Id

--Task 3
SELECT Username, LastName, (IIF(PhoneNumber IS NOT NULL, 1, 0)) as [Has Phone]
FROM Users
ORDER BY LastName

--TASK 4
SELECT q.Title as [Question Title], u.Username as [Author]
FROM Questions q
INNER JOIN Users u
	ON q.UserId = u.Id
ORDER BY q.Id

--TASK 5
SELECT a.Content as [Answer Content], a.CreatedOn as [CreatedOn], u.Username as [Answer Author], q.Title as [Question Title], c.Name as [Category Name]
FROM Answers a
LEFT JOIN Questions q
	ON a.QuestionId = q.Id
LEFT JOIN Categories c
	ON c.Id = q.CategoryId
LEFT JOIN Users u
	ON u.Id = a.UserId
ORDER BY c.Name, u.Username, a.CreatedOn

--TASK 6
SELECT c.Name, q.Title, q.CreatedOn
FROM Categories c
LEFT JOIN Questions q
	ON c.Id = q.CategoryId
ORDER BY c.Name

--TASK 7
SELECT u.Id, u.Username, u.FirstName, u.PhoneNumber, u.RegistrationDate, u.Email
FROM Users u
LEFT JOIN Questions q
	ON u.Id = q.UserId
WHERE u.PhoneNumber IS NULL AND q.Id IS NULL
ORDER BY u.RegistrationDate

--TASK 8
SELECT MIN(CreatedOn) as [MinDate], MAX(CreatedOn) as [MaxDate]
FROM Answers
WHERE YEAR(CreatedOn) BETWEEN 2012 AND 2014

--TASK 9
SELECT TOP 10 a.Content, a.CreatedOn, u.Username
FROM Answers a
JOIN Users u
	ON u.Id = a.UserId
ORDER BY a.CreatedOn

--TASK 10
SELECT a.Content as [Answer Content], q.Title as [Question], c.Name as [Category]
FROM Answers a
JOIN Questions q
	ON q.Id = a.QuestionId
JOIN Categories c
	ON c.Id = q.CategoryId
WHERE 
	(MONTH(a.CreatedOn) = (SELECT MIN(MONTH(CreatedOn)) FROM Answers) OR MONTH(a.CreatedOn) = (SELECT MAX(MONTH(CreatedOn)) FROM Answers)) AND
	YEAR(a.CreatedOn) = (SELECT MAX(YEAR(CreatedOn)) FROM Answers) AND
	a.IsHidden = 1
ORDER BY c.Name

--TASK 11
SELECT c.Name as [Category], COUNT(a.Id) as [Answers Count]
FROM Categories c
LEFT JOIN Questions q
	ON c.Id = q.CategoryId
LEFT JOIN Answers a
	ON a.QuestionId = q.Id
GROUP BY c.Name
ORDER BY [Answers Count] DESC

--TASK 12
SELECT c.Name as [Category], u.Username, u.PhoneNumber, COUNT(a.Id) as [Answers Count]
FROM Categories c
JOIN Questions q
	ON c.Id = q.CategoryId
JOIN Answers a
	ON a.QuestionId = q.Id
JOIN Users u
	ON u.Id = a.UserId
GROUP BY c.Name, u.Username, u.PhoneNumber
HAVING u.PhoneNumber IS NOT NULL
ORDER BY [Answers Count] DESC

--TASK 14
CREATE VIEW AllQuestions
AS
SELECT
	u.Id as UId,
	u.Username,
	u.FirstName,
	u.LastName,
	u.Email,
	u.PhoneNumber,
	u.RegistrationDate,
	q.Id as QId,
	q.Title,
	q.Content,
	q.CategoryId,
	q.UserId,
	q.CreatedOn
FROM
  Questions q
  RIGHT OUTER JOIN Users u on q.UserId = u.Id
  
SELECT * FROM AllQuestions

IF (object_id(N'fn_ListUsersQuestions') IS NOT NULL)
DROP FUNCTION fn_ListUsersQuestions
GO

CREATE FUNCTION fn_ListUsersQuestions()
	RETURNS @tbl_UsersQuestions TABLE(
		UserName NVARCHAR(MAX),
		Questions NVARCHAR(MAX)
	)
AS
BEGIN
	DECLARE UsersCursor CURSOR FOR
		SELECT Username FROM Users
		ORDER BY Username;
	OPEN UsersCursor;
	DECLARE @username NVARCHAR(MAX);
	FETCH NEXT FROM UsersCursor INTO @username;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @questions NVARCHAR(MAX) = NULL;
		SELECT
			@questions = CASE
				WHEN @questions IS NULL THEN CONVERT(NVARCHAR(MAX), Title, 112)
				ELSE @questions + ', ' + CONVERT(NVARCHAR(MAX), Title, 112)
			END
		FROM AllQuestions
		WHERE Username = @username
		ORDER BY Title DESC;

		INSERT INTO @tbl_UsersQuestions
		VALUES(@username, @questions)
		
		FETCH NEXT FROM UsersCursor INTO @username;
	END;
	CLOSE UsersCursor;
	DEALLOCATE UsersCursor;
	RETURN;
END
GO

SELECT * FROM fn_ListUsersQuestions()