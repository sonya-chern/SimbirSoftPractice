using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Services;
using WebApplication.Library.Models;


namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorSr;

        public AuthorController(AuthorService authorSr)
        {
            _authorSr = authorSr;
        }

        /// <summary>
        /// Получить список всех авторов
        /// </summary>
        [HttpGet]
        public IActionResult GetAllAuthor()
        {
            var allAuthor = _authorSr.GetAuthorList();
            return new ObjectResult(allAuthor);
        }

        /// <summary>
        /// Выводит список книг автора: автор + книги + жанры
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetAuthorBook(int authorId)
        {
            var allAuthor = _authorSr.GetAuthorBook(authorId);
            return new ObjectResult(allAuthor);
        }

        /// <summary>
        /// Добавляет автора
        /// </summary>
        [HttpPost]
        public void AddAuthor([FromBody] Author author)
        {
            _authorSr.Create(author);
        }

        /// <summary>
        /// Удаляет автора по ID, если нет книг
        /// </summary>
        [HttpDelete]
        public void DeleteAuthor(int authorId)
        {
            _authorSr.Delete(authorId);       
        }
    }
}
