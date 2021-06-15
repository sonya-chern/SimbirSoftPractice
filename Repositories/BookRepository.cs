using System.Collections.Generic;
using System.Linq;
using WebApplication.Library.Models;
using WebApplication.Library.Context;
using Microsoft.EntityFrameworkCore;
//using WebApplication.Library.


namespace WebApplication.Library.Repositories
{
    public class BookRepository
    {
        private readonly LibraryContext _db;

       // public static List<Book> allBooks = new List<Book>();
        public BookRepository(LibraryContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> GetBookList()
        {
            return _db.Books.Include(a => a.BooksAuthor).Include(g => g.Genres);
        }

        public Book GetBook(int id)
        {
            return _db.Books.Find(id);
        }

        public IQueryable <Book> GetBooksByAuthor(int authorId)
        {
            var result = (IQueryable<Book>)_db.Books.Where(x => x.AuthorId == authorId)
                .Include(a => a.BooksAuthor)
                .Include(g => g.Genres).ToList();
            return result;
        }

        public IQueryable<Book> GetBooksByGenre(Genre genre)
        {
            var result = (IQueryable<Book>)_db.Books.Where(x => x.Genres.Any(y => y.GenreName.Equals(genre)))
                .Include(a => a.BooksAuthor)
                .Include(g => g.Genres).ToList();      
            return result;
        }

        public bool Create(Book book)
        {
            try
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateGenre(Book newBook)
        {
            var record = _db.Books.SingleOrDefault(x => x.BookId == newBook.BookId);
            record.Genres = newBook.Genres;
        }

        public void DeleteById(int bookId)
        {
             _db.Books.Remove(GetBook(bookId));
            _db.SaveChanges();
        }
    }
}
