using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<BookDto> listBooks = new List<BookDto>(3);

        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            return listBooks;
        }

        public IEnumerable<BookDto> GetBookByAuthor(string name)
        {
            foreach (var item in listBooks)
            {
                if (item.authorName == name) 
                    yield return item;
            }
        }

        [HttpPost]
        public List<BookDto> AddBook([FromBody] BookDto book)
        {
            listBooks.Add(book);
            return listBooks;
        }

        public IActionResult DeleteBook(string bookT, string authorN)
        {
            try
            {
                foreach (var item in listBooks)
                {
                    if (item.bookTitle == bookT && item.authorName == authorN) listBooks.Remove(item);
                }
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
