-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 
-- Версия на сървъра: 5.6.21
-- PHP Version: 5.5.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `university`
--

-- --------------------------------------------------------

--
-- Структура на таблица `courses`
--

CREATE TABLE IF NOT EXISTS `courses` (
`Id` int(11) NOT NULL,
  `Students` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `courses_students`
--

CREATE TABLE IF NOT EXISTS `courses_students` (
  `CourseId` int(11) NOT NULL,
  `StudentId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `departments`
--

CREATE TABLE IF NOT EXISTS `departments` (
`Id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Professors` int(11) NOT NULL,
  `Courses` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `department_professors`
--

CREATE TABLE IF NOT EXISTS `department_professors` (
  `DepartmentId` int(11) NOT NULL,
  `ProfessorId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `faculties`
--

CREATE TABLE IF NOT EXISTS `faculties` (
`Id` int(11) NOT NULL,
  `StudentId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `professors`
--

CREATE TABLE IF NOT EXISTS `professors` (
`Id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Titles` int(11) NOT NULL,
  `Courses` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `professor_courses`
--

CREATE TABLE IF NOT EXISTS `professor_courses` (
  `ProfessorId` int(11) NOT NULL,
  `CourseId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `professor_titles`
--

CREATE TABLE IF NOT EXISTS `professor_titles` (
  `ProfessorId` int(11) NOT NULL,
  `TitleId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `students`
--

CREATE TABLE IF NOT EXISTS `students` (
`Id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Telephone` varchar(20) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `titles`
--

CREATE TABLE IF NOT EXISTS `titles` (
`Id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `courses`
--
ALTER TABLE `courses`
 ADD PRIMARY KEY (`Id`), ADD KEY `Students` (`Students`);

--
-- Indexes for table `courses_students`
--
ALTER TABLE `courses_students`
 ADD KEY `StudentId` (`StudentId`), ADD KEY `CourseId` (`CourseId`);

--
-- Indexes for table `departments`
--
ALTER TABLE `departments`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `department_professors`
--
ALTER TABLE `department_professors`
 ADD KEY `DepartmentId` (`DepartmentId`), ADD KEY `ProfessorId` (`ProfessorId`);

--
-- Indexes for table `faculties`
--
ALTER TABLE `faculties`
 ADD PRIMARY KEY (`Id`), ADD KEY `StudentId` (`StudentId`);

--
-- Indexes for table `professors`
--
ALTER TABLE `professors`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `professor_courses`
--
ALTER TABLE `professor_courses`
 ADD KEY `CourseId` (`CourseId`), ADD KEY `ProfessorId` (`ProfessorId`);

--
-- Indexes for table `professor_titles`
--
ALTER TABLE `professor_titles`
 ADD KEY `ProfessorId` (`ProfessorId`), ADD KEY `TitleId` (`TitleId`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
 ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `titles`
--
ALTER TABLE `titles`
 ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `courses`
--
ALTER TABLE `courses`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `departments`
--
ALTER TABLE `departments`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `faculties`
--
ALTER TABLE `faculties`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `professors`
--
ALTER TABLE `professors`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `titles`
--
ALTER TABLE `titles`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Ограничения за дъмпнати таблици
--

--
-- Ограничения за таблица `courses_students`
--
ALTER TABLE `courses_students`
ADD CONSTRAINT `courses_students_ibfk_1` FOREIGN KEY (`StudentId`) REFERENCES `students` (`Id`),
ADD CONSTRAINT `courses_students_ibfk_2` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`Id`);

--
-- Ограничения за таблица `department_professors`
--
ALTER TABLE `department_professors`
ADD CONSTRAINT `department_professors_ibfk_1` FOREIGN KEY (`DepartmentId`) REFERENCES `departments` (`Id`),
ADD CONSTRAINT `department_professors_ibfk_2` FOREIGN KEY (`ProfessorId`) REFERENCES `professors` (`Id`);

--
-- Ограничения за таблица `faculties`
--
ALTER TABLE `faculties`
ADD CONSTRAINT `faculties_ibfk_1` FOREIGN KEY (`StudentId`) REFERENCES `students` (`Id`);

--
-- Ограничения за таблица `professor_courses`
--
ALTER TABLE `professor_courses`
ADD CONSTRAINT `professor_courses_ibfk_1` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`Id`),
ADD CONSTRAINT `professor_courses_ibfk_2` FOREIGN KEY (`ProfessorId`) REFERENCES `professors` (`Id`);

--
-- Ограничения за таблица `professor_titles`
--
ALTER TABLE `professor_titles`
ADD CONSTRAINT `professor_titles_ibfk_1` FOREIGN KEY (`ProfessorId`) REFERENCES `professors` (`Id`),
ADD CONSTRAINT `professor_titles_ibfk_2` FOREIGN KEY (`TitleId`) REFERENCES `titles` (`Id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
