using System.Linq;
using WebApplication.Library.Models;
using WebApplication.Library.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Library.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _db;

        public AuthorRepository(LibraryContext db)
        {
            _db = db;
        }

        public IQueryable<Author> GetAuthorList()
        {
            return _db.Authors;
        }

        public Author GetAuthor(int id)
        {
            return _db.Authors.Find(id);
        }

        /// <summary>
        /// Выводит список книг автора: автор + книги + жанры
        /// </summary>
        public IQueryable<Author> GetBookList(int authorId)
        { 
            var bookList = (IQueryable<Author>)_db.Authors.Find(authorId).Books.ToList();
            return bookList;
        }

        public bool Create(Author author)
        {
            try
            {
                _db.Authors.Add(author);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Update(Author newAuthor)
        {
            Author author = _db.Authors.Find(newAuthor.AuthorId);
            author.FirstName = newAuthor.FirstName;
            author.LastName = newAuthor.LastName;
            author.Patronymic = newAuthor.Patronymic;
            author.BirthDay = newAuthor.BirthDay;
            _db.Entry(author).State = EntityState.Modified;
            _db.SaveChanges();
        }
        
        /// <summary>
        /// Удаляет автора только если у него нет книг 
        /// </summary>
        public bool DeleteAuthor(int authorId)
        {
            Author author = _db.Authors.Find(authorId);
            int sizeAuthorBooks = author.Books.Count();
            if (sizeAuthorBooks == 0)
            {
                _db.Authors.Remove(author);
                _db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
