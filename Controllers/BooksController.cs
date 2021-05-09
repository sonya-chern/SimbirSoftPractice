using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;
using System.Collections.Generic;
 
namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class BooksController : ControllerBase
    {
        public static List<BookDto> listBooks = new List<BookDto>();

        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            return listBooks;
        }

        [HttpGet ("{string}")]
        public IEnumerable<BookDto> GetBookByAuthor(string nameAuthor)
        {
            return listBooks.FindAll(item => item.AuthorName == nameAuthor);
        }

        [HttpPost]
        public IEnumerable<BookDto> AddBook([FromBody] BookDto book)
        {
            listBooks.Add(book);
            return listBooks;
        }

        [HttpDelete]
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
