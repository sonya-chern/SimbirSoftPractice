using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;
using WebApplication.Library.Repositories;
using WebApplication.Library.Context;
using System.Collections.Generic;

 
namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRp;

        public BooksController(BookRepository bookRp)
        {
            _bookRp = bookRp;
        }

        [HttpGet("{id}")]
        public IQueryable<Book> GetBooksByAuthorId(int authorId)
        {
            var listBooks = _bookRp.GetBooksByAuthor(authorId);
            return listBooks;
        }

        /// <summary>
        /// получение всех книг по жанру
        /// </summary>

        [HttpGet]
        public IQueryable<Book> GetGenreListBook(Genre genre)
        {
            return _bookRp.GetBooksByGenre(genre);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookRp.Create(book);
            _bookRp.Save();
            return Ok(book);
        }

        [HttpPut]
        public IActionResult UpdateBookGenre(Book newBook)
        {
            Book book = _bookRp.GetBook(newBook.BookId);
            if (book != null)
            {
                _bookRp.UpdateGenre(newBook);
                return Ok();
            }
            else return NotFound("Книга не найдена");
        }
        [HttpDelete]
        public IActionResult DeleteById(int bookId)
        {
            Book book = _bookRp.GetBook(bookId);
            if (book != null)
            {
                if (book.AuthorId == 0)
                {
                    _bookRp.DeleteById(bookId);
                    _bookRp.Save();
                    return Ok();
                }
                else return NotFound("Книга находится у пользователя");
            }
            else return NotFound("Книга с данным ID не найдена");
        }
    }
}
