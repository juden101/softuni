INSERT INTO WorkHours VALUES
(2, CONVERT(DATETIME, '2015-07-1'), 'sadf', 4.5, '123123'),
(3, CONVERT(DATETIME, '2015-07-2'), 'yrytrfd', 2.0, 'rewererwrw'),
(4, CONVERT(DATETIME, '2015-07-3'), 'asdasdad', 8, 'Cwqqqq')

GO

UPDATE WorkHours
SET Task = 'Completed task'
WHERE WorkHoursId = 1

GO

UPDATE WorkHours
SET Comment = 'This task has been completed'
WHERE Task like 'Completed%'

GO

DELETE FROM WorkHours
WHERE WorkHoursId = 2

GO