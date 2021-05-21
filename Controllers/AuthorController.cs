using WebApplication.Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;


namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorRepository _authorRp;

        public AuthorController(AuthorRepository authorRp)
        {
            _authorRp = authorRp;
        }

        [HttpGet]
        public IActionResult GetAllAuthor()
        {
            var allAuthor = _authorRp.GetAuthorList();
            return Ok(allAuthor);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorBook(int authorId)
        {
            var author = _authorRp.GetAuthor(authorId);
            if (author != null)
            {
                var allAuthorBook = _authorRp.GetBookList(author);
                return Ok(allAuthorBook);
            }
            else return NotFound("Автор не найден");
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] Author author)
        {
            _authorRp.Create(author);
            _authorRp.Save();
            var authorAndBooks = _authorRp.GetAuthor(author.AuthorId).Books;
            return Ok(authorAndBooks);
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int authorId)
        {
            var author = _authorRp.GetAuthor(authorId);
            if(author!=null)
            {
                if (_authorRp.DeleteAuthor(author))
                {
                    return Ok("Автор удален");
                }
                else return BadRequest("Автор не может быть удален");
            }
            else return NotFound("Автор не найден");
        }
    }
}
