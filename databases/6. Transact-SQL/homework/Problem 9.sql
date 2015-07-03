USE SoftUni
GO

/* ENABLE CLR EXTERNAL USE */
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

/* LOAD EXTERNAL ASSEMBLY PATH SHOUD ASSSIGN THE PATH TO StrConcat.dll (FROM Homework-Transact-SQL FOLDER) */
CREATE ASSEMBLY StrConcat 
FROM 'C:\StrConcat.dll'
WITH permission_set = Safe;
GO

CREATE AGGREGATE StrConcat (@input nvarchar(200)) RETURNS nvarchar(max)
EXTERNAL NAME StrConcat.StrConcat;
GO

SELECT dbo.StrConcat(FirstName + ' ' + LastName)
FROM Employees
GO