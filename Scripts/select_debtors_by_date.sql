SELECT 
	person.first_name,
	person.last_name,
	person.patronymic,
	book.book_title,
	DATEDIFF ('2021-04-28', library_card.book_taken_date ) as days_of_delay
FROM person 
	LEFT JOIN  library_card
		ON person.person_id = library_card.person_id
	LEFT JOIN  book
		ON library_card.book_id = book.book_id
	WHERE DATEDIFF ('2021-04-28', library_card.book_taken_date ) > 14