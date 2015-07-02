CREATE TABLE Users (
  UserID int IDENTITY,
  Username nvarchar(50) UNIQUE,
  Password nvarchar(50) NOT NULL,
  FullName nvarchar(100) NOT NULL,
  LastLoginTime datetime NOT NULL,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CONSTRAINT CC_UsernameLength CHECK (DATALENGTH(Username) > 4)
)

GO