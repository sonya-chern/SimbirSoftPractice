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

        public IQueryable<Genre> GetGenreNumberBooks(Genre genre)
        {
            var result = (IQueryable<Genre>)_db.Genres.Where(g => g.GenreId == genre.GenreId)
                .Select(g => new { Genre = g.GenreName, Count = g.Books.Count() }).ToList();
            return result;
        }

        public void Create(Genre genre)
        {
            _db.Genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Genre genre = _db.Genres.Find(id);
            if (genre != null)
                _db.Genres.Remove(genre);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
