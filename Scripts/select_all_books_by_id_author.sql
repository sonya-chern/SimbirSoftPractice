SELECT 
	author.first_name,
	author.last_name,
	author.patronymic,
	book.book_title,
	dim_genre.genre_name
FROM author 
	LEFT JOIN  book
		ON author.author_id = book.author_id
	LEFT JOIN  book_genre_lnk
		ON book.book_id = book_genre_lnk.book_id
	LEFT JOIN  dim_genre
		ON book_genre_lnk.genre_id = dim_genre.genre_id
	WHERE author.author_id = 2
	