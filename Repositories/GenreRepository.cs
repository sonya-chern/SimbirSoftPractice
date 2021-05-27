using System.Linq;
using WebApplication.Library.Models;
using WebApplication.Library.Context;
using Microsoft.EntityFrameworkCore;


namespace WebApplication.Library.Repositories
{
    public class GenreRepository
    {
        private readonly LibraryContext _db;

        public GenreRepository(LibraryContext db)
        {
            _db = db;
        }

        public IQueryable<Genre> GetGenreList()
        {
            return _db.Genres;
        }

        public Genre GetGenre(int id)
        {
            return _db.Genres.Find(id);
        }

        /// <summary>
        /// Выводит статистику Жанр - количество книг
        /// </summary>
        public IQueryable<Genre> GetGenreNumberBooks(Genre genre)
        {
            var result = (IQueryable<Genre>)_db.Genres.Where(g => g.GenreId == genre.GenreId)
                .Select(g => new { Genre = g.GenreName, Count = g.Books.Count() }).ToList();
            return result;
        }

        public bool Create(Genre genre)
        {
            try
            {
                _db.Genres.Add(genre);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Update(int genreId, Genre newGenre)
        {
            Genre genre = _db.Genres.Find(genreId);
            genre.GenreName = newGenre.GenreName;
            _db.Entry(genre).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int genreId)
        {
            Genre genre = GetGenre(genreId);
            _db.Genres.Remove(genre);
            _db.SaveChanges();
        }
    }
}
