-- phpMyAdmin SQL Dump
-- version 4.7.1
-- https://www.phpmyadmin.net/
--
-- Host: sql11.freemysqlhosting.net
-- Generation Time: Jun 21, 2021 at 06:48 PM
-- Server version: 5.5.62-0ubuntu0.14.04.1
-- PHP Version: 7.0.33-0ubuntu0.16.04.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sql11418815`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`sql11418815`@`%` PROCEDURE `CreateEventForUser` (IN `getTitle` VARCHAR(20), IN `getDescription` VARCHAR(50), IN `getDate` DATE, IN `getPriority` ENUM('Low','Medium','High'), IN `getLogin` VARCHAR(20))  BEGIN
    DECLARE getUserId INT;
    SELECT users.id INTO getUserId FROM users WHERE login = getLogin;
    INSERT INTO sql11418815.events
    VALUES (
            0,
            getTitle,
            getDescription,
            getDate,
            getPriority,
            getUserId
           );
end$$

CREATE DEFINER=`sql11418815`@`%` PROCEDURE `CreateUser` (IN `getLogin` VARCHAR(20), IN `getPassword` VARCHAR(20))  BEGIN
    INSERT INTO users (login, password) VALUES (getLogin, getPassword);
end$$

CREATE DEFINER=`sql11418815`@`%` PROCEDURE `DeleteEventForUser` (`getTitle` VARCHAR(20), `getDescription` VARCHAR(50), `getDate` DATE, `getPriority` ENUM('Low','Medium','High'), `getLogin` VARCHAR(20))  BEGIN
    DECLARE getUserId INT;
    SELECT users.id INTO getUserId FROM users WHERE login = getLogin;
    DELETE FROM sql11418815.events WHERE
          title = getTitle AND
          description = getDescription AND
          date = getDate AND
          priority = getPriority AND
          user_id = getUserId;
end$$

CREATE DEFINER=`sql11418815`@`%` PROCEDURE `EditEventForUser` (`oldTitle` VARCHAR(20), `oldDescription` VARCHAR(50), `oldDate` DATE, `oldPriority` ENUM('Low','Medium','High'), `newTitle` VARCHAR(20), `newDescription` VARCHAR(50), `newDate` DATE, `newPriority` ENUM('Low','Medium','High'), `getLogin` VARCHAR(20))  BEGIN
    DECLARE getUserId INT;
    SELECT users.id INTO getUserId FROM users WHERE login = getLogin;
    UPDATE sql11418815.events
    SET
        title = newTitle,
        description = newDescription,
        date = newDate,
        priority = newPriority
    WHERE
          title = oldTitle AND
          description = oldDescription AND
          date = oldDate AND
          priority = oldPriority AND
          user_id = getUserId;
end$$

CREATE DEFINER=`sql11418815`@`%` PROCEDURE `GetEventsByDateForUser` (IN `getLogin` VARCHAR(20), IN `getDate` DATE)  BEGIN
    SELECT *
    FROM sql11418815.events INNER JOIN users on events.user_id = users.id
    WHERE login = getLogin AND date = getDate;
end$$

CREATE DEFINER=`sql11418815`@`%` PROCEDURE `GetUsersByLogin` (IN `getLogin` VARCHAR(20))  BEGIN
    SELECT *
    FROM users
    WHERE login = getLogin;
end$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `events`
--

CREATE TABLE `events` (
  `id` int(11) NOT NULL,
  `title` varchar(20) NOT NULL,
  `description` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `priority` enum('Low','Medium','High') NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `events`
--

INSERT INTO `events` (`id`, `title`, `description`, `date`, `priority`, `user_id`) VALUES
(12, 'Zaprezentuj Projekt', 'Zaprezentuj projekt z programowania obiektowego i ', '2021-06-22', 'High', 8),
(13, 'Poucz sie na egzamin', 'egzamin z baz danych', '2021-06-22', 'Medium', 8),
(14, 'Posprzataj', 'Posprzataj mieszkanie', '2021-06-21', 'Low', 8),
(15, 'Idz pobiegac', 'spal 300 kcal', '2021-06-24', 'Medium', 8);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `login` varchar(20) CHARACTER SET utf8 NOT NULL,
  `password` varchar(20) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login`, `password`) VALUES
(8, 'Julian', 'qwerty');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `events`
--
ALTER TABLE `events`
  ADD PRIMARY KEY (`id`),
  ADD KEY `events_users_id_fk` (`user_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `events`
--
ALTER TABLE `events`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `events`
--
ALTER TABLE `events`
  ADD CONSTRAINT `events_users_id_fk` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
