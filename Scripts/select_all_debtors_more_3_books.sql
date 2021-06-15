SELECT 
	person.first_name,
	person.last_name,
	person.patronymic,
	COUNT(library_card.book_id) as count_books
FROM person 
	LEFT JOIN  library_card
		ON person.person_id = library_card.person_id	
	WHERE DATEDIFF ('2021-04-28', library_card.book_taken_date ) > 14 GROUP BY library_card.person_id HAVING COUNT(library_card.book_id)>3