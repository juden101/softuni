-- Problem 2. Add an index to speed-up the search by date 
-- Creating index. Costs 15 seconds

CREATE INDEX CurrentTime_Index
ON DateAndTex(CurrentTime)

-- DROP INDEX DateAndTex.CurrentTime_Index

-- clear buffers and cache
DBCC DROPCLEANBUFFERS
DBCC FREEPROCCACHE

-- after indexing -- Get entities for first minute. Costed 2 seconds.
SELECT COUNT(r.TimeRange)
FROM (SELECT t.CurrentTime AS TimeRange
FROM DateAndTex t
WHERE t.CurrentTime 
BETWEEN CONVERT(DATETIME, '2015-08-06 20:27:35.973', 121) 
AND CONVERT(DATETIME, '2015-08-06 20:28:35.973', 121)) r