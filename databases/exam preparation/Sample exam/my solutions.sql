-- Task 1
SELECT Title
FROM Ads
ORDER BY Title

-- Task 2
SELECT a.Title, a.Date
FROM Ads a
WHERE a.Date BETWEEN '26-Dec-2014' AND '2-Jan-2015'
ORDER BY a.Date

-- Task 3
SELECT
	Title,
	Date,
	(IIF(ImageDataURL IS NOT NULL, 'yes', 'no')) as [Has Image]
FROM Ads
ORDER BY Id

-- Task 4
SELECT *
FROM Ads
WHERE
	TownId IS NULL OR
	CategoryId IS NULL OR
	ImageDataURL IS NULL
ORDER BY Id

-- Task 5
SELECT
	Title,
	t.Name as [Town]
FROM Ads a
LEFT JOIN Towns t
	ON a.TownId = t.Id

-- Task 6
SELECT
	a.Title,
	c.Name as [CategoryName],
	t.Name as [TownName],
	s.Status
FROM Ads a
LEFT JOIN Towns t
	ON a.TownId = t.Id
LEFT JOIN Categories c
	ON a.CategoryId = c.Id
LEFT JOIN AdStatuses s
	ON s.Id = a.StatusId

-- Task 7
SELECT
	a.Title,
	c.Name as [CategoryName],
	t.Name as [TownName],
	s.Status
FROM Ads a
LEFT JOIN Towns t
	ON a.TownId = t.Id
LEFT JOIN Categories c
	ON a.CategoryId = c.Id
LEFT JOIN AdStatuses s
	ON s.Id = a.StatusId
WHERE
	t.Name IN ('Sofia', 'Blagoevgrad', 'Stara Zagora') AND
	s.Status = 'Published'
ORDER BY a.Title

-- Task 8
SELECT
	MIN(Date) as [MinDate],
	MAX(Date) as [MaxDate]
FROM Ads

-- Task 9
SELECT TOP 10
	a.Title,
	a.Date,
	s.Status
FROM Ads a
JOIN AdStatuses s
	ON a.StatusId = s.Id
ORDER BY a.Date DESC

-- Task 10
SELECT
	a.Id,
	a.Title,
	a.Date,
	s.Status
FROM Ads a
JOIN AdStatuses s
	ON a.StatusId = s.Id
WHERE
	s.Status != 'Published' AND
	MONTH(a.Date) = (SELECT MONTH(MIN(Date)) FROM Ads) AND
	YEAR(a.Date) = (SELECT YEAR(MIN(Date)) FROM Ads)
ORDER BY a.Id

-- Task 11
SELECT
	s.Status,
	COUNT(a.Id) as [Count]
FROM AdStatuses s
JOIN Ads a
	ON s.Id = a.StatusId
GROUP BY s.Status

-- Task 12
SELECT
	t.Name [Town Name],
	s.Status,
	COUNT(a.Id) as [Count]
FROM Ads a
JOIN Towns t
	ON a.TownId = t.Id
JOIN AdStatuses s
	ON a.StatusId = s.Id
GROUP BY t.Name, s.Status
ORDER BY t.Name

-- Task 13
SELECT 
  u.UserName as UserName, 
  COUNT(a.Id) as AdsCount,
  (IIF(admins.UserName IS NULL, 'no', 'yes')) AS IsAdministrator
FROM AspNetUsers u
LEFT JOIN Ads a
	ON u.Id = a.OwnerId
LEFT JOIN (
    SELECT DISTINCT u.UserName
	FROM AspNetUsers u
	  LEFT JOIN AspNetUserRoles ur ON ur.UserId = u.Id
	  LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id
	WHERE r.Name = 'Administrator') AS admins ON u.UserName = admins.UserName
GROUP BY OwnerId, u.UserName, admins.UserName
ORDER BY u.UserName

-- Task 14
SELECT
	COUNT(a.Id) as [AdsCount],
	ISNULL(t.Name, '(no town)') as [Town]
FROM Ads a
LEFT JOIN Towns t
	ON t.Id = a.TownId
GROUP BY t.Name
HAVING COUNT(a.Id) IN (2, 3)
ORDER BY [Town]

-- Task 15
SELECT
	a1.Date as [FirstDate],
	a2.Date as [SecondDate]
FROM Ads a1, Ads a2
WHERE
	a2.Date > a1.Date AND
	DATEDIFF(second, a1.Date, a2.Date) < 43200
ORDER BY [FirstDate], [SecondDate]

-- Task 16
BEGIN TRAN
-- 1

CREATE TABLE Countries(
	Id int IDENTITY NOT NULL,
	Name nvarchar(MAX) NOT NULL,
	CONSTRAINT PK_Countries PRIMARY KEY (Id)
)

ALTER TABLE Towns 
ADD CountryId int
GO

ALTER TABLE Towns WITH CHECK ADD CONSTRAINT FK_Towns_Countries
FOREIGN KEY (CountryId) REFERENCES Countries(Id)
GO

-- 2
INSERT INTO Countries(Name) VALUES ('Bulgaria'), ('Germany'), ('France')
UPDATE Towns SET CountryId = (SELECT Id FROM Countries WHERE Name='Bulgaria')
INSERT INTO Towns VALUES
('Munich', (SELECT Id FROM Countries WHERE Name='Germany')),
('Frankfurt', (SELECT Id FROM Countries WHERE Name='Germany')),
('Berlin', (SELECT Id FROM Countries WHERE Name='Germany')),
('Hamburg', (SELECT Id FROM Countries WHERE Name='Germany')),
('Paris', (SELECT Id FROM Countries WHERE Name='France')),
('Lyon', (SELECT Id FROM Countries WHERE Name='France')),
('Nantes', (SELECT Id FROM Countries WHERE Name='France'))

-- 3
UPDATE Ads
SET TownId = (SELECT Id FROM Towns WHERE Name='Paris')
WHERE DATENAME(WEEKDAY, Date) = 'Friday'

-- 4
UPDATE Ads
SET TownId = (SELECT Id FROM Towns WHERE Name='Hamburg')
WHERE DATENAME(WEEKDAY, Date) = 'Thursday'

-- 5
DELETE FROM Ads
FROM Ads a
JOIN AspNetUsers u
	ON a.OwnerId = u.Id
JOIN AspNetUserRoles ur
	ON ur.UserId = u.Id
JOIN AspNetRoles r
	ON r.Id = ur.RoleId
WHERE r.Name = 'Partner'

-- 6
INSERT INTO Ads(Title, Text, OwnerId, Date, StatusId)
VALUES (
	'Free Book',
	'Free C# Book',
	(SELECT Id FROM AspNetUsers WHERE username = 'nakov'),
	GETDATE(),
	(SELECT Id FROM AdStatuses WHERE Status = 'Waiting Approval'))

-- 7
SELECT
	t.Name as [Town],
	c.Name as [Country],
	COUNT(a.Id) as [AdsCount]
FROM Ads a
FULL OUTER JOIN Towns t ON a.TownId = t.Id
FULL OUTER JOIN Countries c ON t.CountryId = c.Id
GROUP BY t.Name, c.Name
ORDER BY t.Name, c.Name

ROLLBACK TRAN

-- Task 17
CREATE VIEW AllAds AS
SELECT 
	a.Id,
	a.Title, 
	u.UserName AS Author,
	a.Date,
	t.Name AS Town, 
	c.Name AS Category,
	s.Status AS Status
FROM
	Ads a
	LEFT JOIN Towns t on a.TownId = t.Id
	LEFT JOIN Categories c on a.CategoryId = c.Id
	LEFT JOIN AdStatuses s on a.StatusId = s.Id
	LEFT JOIN AspNetUsers u on u.Id = a.OwnerId

IF (object_id(N'fn_ListUsersAds') IS NOT NULL)
DROP FUNCTION fn_ListUsersAds
GO

CREATE FUNCTION fn_ListUsersAds()
	RETURNS @tbl_UsersAds TABLE(
		UserName NVARCHAR(MAX),
		AdDates NVARCHAR(MAX))
AS
BEGIN
	DECLARE UsersCursor CURSOR FOR
		SELECT UserName FROM AspNetUsers
		ORDER BY UserName DESC;
	OPEN UsersCursor;
	DECLARE @username NVARCHAR(MAX);
	FETCH NEXT FROM UsersCursor INTO @username;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @ads NVARCHAR(MAX) = NULL;
		SELECT
			@ads = CASE
				WHEN @ads IS NULL THEN CONVERT(NVARCHAR(MAX), Date, 112)
				ELSE @ads + '; ' + CONVERT(NVARCHAR(MAX), Date, 112)
			END
		FROM AllAds
		WHERE Author = @username
		ORDER BY Date;

		INSERT INTO @tbl_UsersAds
		VALUES(@username, @ads)
		
		FETCH NEXT FROM UsersCursor INTO @username;
	END;
	CLOSE UsersCursor;
	DEALLOCATE UsersCursor;
	RETURN;
END
GO

SELECT * FROM fn_ListUsersAds()

---------------------------------------------------------

DROP DATABASE IF EXISTS `orders`;

CREATE DATABASE `orders` CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE `orders`;

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `customers`;

CREATE TABLE `customers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `orders`;

CREATE TABLE `orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  PRIMARY KEY (`id`)
);

DROP TABLE IF EXISTS `order_items`;

CREATE TABLE `order_items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_order_items_orders_idx` (`order_id`),
  KEY `fk_order_items_products_idx` (`product_id`),
  CONSTRAINT `fk_order_items_orders` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_items_products` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
);

INSERT INTO `products` VALUES (1,'beer',1.20), (2,'cheese',9.50), (3,'rakiya',12.40), (4,'salami',6.33), (5,'tomatos',2.50), (6,'cucumbers',1.35), (7,'water',0.85), (8,'apples',0.75);
INSERT INTO `customers` VALUES (1,'Peter'), (2,'Maria'), (3,'Nakov'), (4,'Vlado');
INSERT INTO `orders` VALUES (1,'2015-02-13 13:47:04'), (2,'2015-02-14 22:03:44'), (3,'2015-02-18 09:22:01'), (4,'2015-02-11 20:17:18');
INSERT INTO `order_items` VALUES (12,4,6,2.00), (13,3,2,4.00), (14,3,5,1.50), (15,2,1,6.00), (16,2,3,1.20), (17,1,2,1.00), (18,1,3,1.00), (19,1,4,2.00), (20,1,5,1.00), (21,3,1,4.00), (22,1,1,3.00);

SELECT
  p.name AS product_name,
  COUNT(oi.product_id) AS num_orders,
  IFNULL(SUM(oi.quantity), 0) as quantity,
  p.price,
  IFNULL(SUM(oi.quantity) * p.price, 0) AS total_price
FROM
  products p
  LEFT JOIN order_items oi ON p.id = oi.product_id
  LEFT JOIN orders o ON oi.order_id = o.id
GROUP BY
  p.id, p.name, p.price
ORDER BY
  p.name