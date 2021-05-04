using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;
using System.Collections.Generic;

namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class BooksController : ControllerBase
    {
        public static List<BookDto> listBooks = new List<BookDto>();

        public BooksController()
        {
            BooksController booksController = new BooksController();
        }

        [HttpGet(template: "get")]
        public IEnumerable<BookDto> GetBooks()
        {
            return listBooks;
        }

        [HttpGet]
        public IEnumerable<BookDto> GetBookByAuthor(string nameAuthor)
        {
            return listBooks.FindAll(item => item.AuthorName == nameAuthor);
        }

        [HttpPost(template: "post")]
        public List<BookDto> AddBook([FromBody] BookDto book)
        {
            listBooks.Add(book);
            return listBooks;
        }

        [HttpDelete(template: "delete")]
        public IActionResult DeleteBook(string bookT, string nameAuthor)
        {
            foreach (var item in listBooks)
            {
                if (item.BookTitle == bookT && item.AuthorName == nameAuthor)
                {
                    listBooks.Remove(item);
                }
            }
            return Ok();
        }
    }
}
