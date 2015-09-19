-- mysql -u root -p

CREATE DATABASE SoftUniSystem;
USE SoftUniSystem

CREATE TABLE users(
	Id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
	Username VARCHAR(64) NOT NULL UNIQUE,
	Password CHAR(96) NOT NULL,
	FullName VARCHAR(100) NOT NULL
);

GRANT SELECT ON SoftUniSystem.users
TO loginform@localhost
IDENTIFIED BY 'fghjudighfduishgiufdsw';

CREATE TABLE books(
	Id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
	Title VARCHAR(200) NOT NULL
);

INSERT INTO books (Title) 
VALUES ("100 Bullets Book Two"),
("100%"),
("Silent_scream"),
("Boundary clossed"),
("The Altar Girl: A Prequel"),
("A Spirited Tail"),
("Bill O'Reilly's Legends and Lies: The Real West"),
("The Whole30: The 30-Day Guide to Total Health and Food Freedom")

CREATE TABLE Messages(
	Id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
	Content VARCHAR(500) NOT NULL,
	Username VARCHAR(64) NOT NULL
);