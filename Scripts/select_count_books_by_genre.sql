SELECT 
	dim_genre.genre_name,
	COUNT(*) as count_books
FROM dim_genre 
	LEFT JOIN  book_genre_lnk
		ON dim_genre.genre_id = book_genre_lnk.genre_id
	WHERE dim_genre.genre_id = 2
	