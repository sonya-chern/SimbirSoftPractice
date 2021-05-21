using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Library.Models;
using WebApplication.Library.ModelsDTO;
using WebApplication.Library.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


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

        public void Create(Book book)
        {
            _db.Books.Add(book);
        }

        public void UpdateGenre(Book book)
        {
            var record = _db.Books.SingleOrDefault(x => x.BookId == book.BookId);
            record.Genres = book.Genres;
        }

        public void DeleteById(int bookId)
        {
             _db.Books.Remove(GetBook(bookId));
        }

        public void Save()
        {
            _db.SaveChanges();
        }
       
    }
}
