CREATE TABLE Groups (
  GroupId int IDENTITY,
  Name nvarchar(50) UNIQUE,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupId)
)

GO