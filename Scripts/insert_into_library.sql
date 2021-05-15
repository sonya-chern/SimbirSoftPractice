INSERT INTO `author` (first_name,last_name,patronymic,birth_date) VALUES ('Tolstoy','Leo','Nikolaevich','1828-09-09');
INSERT INTO `author` (first_name,last_name,patronymic,birth_date) VALUES ('Hugo','Viktor','','1802-02-26');
INSERT INTO `author` (first_name,last_name,patronymic,birth_date) VALUES ('Pushkin','Alexander','Sergeevich','1799-06-06');

INSERT INTO `book` (book_title,author_id) VALUES ('War and Peace', 1);
INSERT INTO `book` (book_title,author_id) VALUES ('Notre-Dame de Paris', 2);
INSERT INTO `book` (book_title,author_id) VALUES ('Ruslan and Lyudmila', 3);

INSERT INTO `dim_genre` (genre_name) VALUES ('russian prose');
INSERT INTO `dim_genre` (genre_name) VALUES ('novel');
INSERT INTO `dim_genre` (genre_name) VALUES ('fairy tale');

INSERT INTO `person` (first_name,last_name,patronymic,birth_date) VALUES ('Petrov','Alexander','Sergeevich','1998-03-03');
INSERT INTO `person` (first_name,last_name,patronymic,birth_date) VALUES ('Jamson','John','','1988-08-23');
INSERT INTO `person` (first_name,last_name,patronymic,birth_date) VALUES ('Petrov','Vlad','Sergeevich','1998-11-07');

INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (1,1,'2021-03-23');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (3,1,'2021-03-23');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (1,2,'2021-04-11');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (2,2,'2021-04-28');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (3,1,'2021-03-22');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (2,1,'2021-03-14');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (3,1,'2021-03-22');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (2,2,'2021-03-14');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (1,2,'2021-03-14');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (1,3,'2021-03-14');
INSERT INTO `library_card` (book_id,person_id,book_taken_date) VALUES (1,2,'2021-03-11');

INSERT INTO `book_genre_lnk` (book_id,genre_id) VALUES (1,1);
INSERT INTO `book_genre_lnk` (book_id,genre_id) VALUES (2,2);
INSERT INTO `book_genre_lnk` (book_id,genre_id) VALUES (3,3);
INSERT INTO `book_genre_lnk` (book_id,genre_id) VALUES (1,2);

