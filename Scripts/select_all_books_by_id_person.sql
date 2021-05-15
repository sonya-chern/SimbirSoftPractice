SELECT 
	book.book_title,
	author.first_name,
	author.last_name,
	author.patronymic,
	dim_genre.genre_name
FROM person 
	LEFT JOIN  library_card
		ON person.person_id = library_card.person_id
	LEFT JOIN  book
		ON library_card.book_id = book.book_id
	LEFT JOIN  author
		ON book.author_id=author.author_id
	LEFT JOIN  book_genre_lnk
		ON book.book_id = book_genre_lnk.book_id
	LEFT JOIN  dim_genre
		ON book_genre_lnk.genre_id = dim_genre.genre_id
	WHERE person.person_id = 1
	