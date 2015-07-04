UPDATE Users
SET Password = NULL
WHERE LastLoginTime < '10/3/2010'