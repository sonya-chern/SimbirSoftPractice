CREATE DATABASE IF NOT EXISTS `library`;

USE `library`;

CREATE TABLE `author` (
  `author_id` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `patronymic` varchar(100) DEFAULT NULL,
  `birth_date` date NOT NULL
) ENGINE=InnoDB;

CREATE TABLE `book` (
  `book_id` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `book_title` varchar(255) NOT NULL,
  `author_id` int(11) NOT NULL,
  FOREIGN KEY (`author_id`) REFERENCES `author` (`author_id`)
) ENGINE=InnoDB;

CREATE TABLE `dim_genre` (
  `genre_id` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `genre_name` varchar(100) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE `book_genre_lnk` (
  `book_id` int(11) NOT NULL,
  `genre_id` int(11) NOT NULL,
  FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`),
  FOREIGN KEY (`genre_id`) REFERENCES `dim_genre` (`genre_id`)
) ENGINE=InnoDB;

CREATE TABLE `person` (
  `person_id` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `patronymic` varchar(100) DEFAULT NULL,
  `birth_date` date NOT NULL
) ENGINE=InnoDB;

CREATE TABLE `library_card` (
  `library_card_id` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `book_id` int(11) NOT NULL,
  `person_id` int(11) NOT NULL,
  `book_taken_date` date NOT NULL,
  FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`),
  FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB;
