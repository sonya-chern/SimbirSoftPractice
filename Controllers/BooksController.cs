using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;
using WebApplication.Library.Services;

 
namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        
        /// <summary>
        /// получить все книги автора(автор-книги-жанры)
        /// </summary>
        [HttpGet("{id}")]
        public IQueryable<Book> GetBooksByAuthorId(int authorId)
        {
            return _bookService.GetBooksByAuthor(authorId);
        }

        /// <summary>
        /// получить все книги по жанру (жанр-книги)
        /// </summary>
        [HttpGet]
        public IQueryable<Book> GetGenreListBook(Genre genre)
        {
            return _bookService.GetBooksByGenre(genre);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.Create(book);
            return Ok(book);
        }

        /// <summary>
        /// Изменить жанр/жанры у книги
        /// </summary>
        [HttpPut]
        public IActionResult UpdateBookGenre([FromBody] Book newBook)
        {
            _bookService.Update(newBook);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int bookId)
        {
           _bookService.Delete(bookId);
           return Ok();
        }
    }
}
