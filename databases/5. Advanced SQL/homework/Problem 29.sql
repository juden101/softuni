CREATE TABLE WorkHours (
  WorkHoursId int IDENTITY NOT NULL,
  EmployeeId int NOT NULL,
  Date datetime NOT NULL,
  Task nvarchar(100) NOT NULL,
  Hours float NOT NULL,
  Comment nvarchar(MAX)
  CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHoursId)
  CONSTRAINT FK_Employees_WorkHours FOREIGN KEY(EmployeeId) REFERENCES Employees(EmployeeId)
)

GO