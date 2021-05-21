using System.Linq;
using WebApplication.Library.Models;
using WebApplication.Library.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Library.Repositories
{
    public class AuthorRepository
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

        public IQueryable<Author> GetBookList(Author author)
        {
            var bookList = (IQueryable<Author>)author.Books.ToList();
            return bookList;
        }

        public void Create(Author author)
        {
            _db.Authors.Add(author);
        }

        public void Update(Author author)
        {
            _db.Entry(author).State = EntityState.Modified;
        }
        
        /// <summary>
        /// метод удаляет автора только если у него нет книг 
        /// </summary>
        public bool DeleteAuthor(Author author)
        {
            int sizeAuthorBooks = author.Books.Count();
            if (sizeAuthorBooks == 0)
            {
                _db.Authors.Remove(author);
                Save();
                return true;
            }
            else return false;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
