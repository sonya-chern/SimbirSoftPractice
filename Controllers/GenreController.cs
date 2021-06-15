using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;
using WebApplication.Library.Services;

namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GenreController : ControllerBase
    {
        private readonly GenreService _genreSr;

        public GenreController(GenreService genreSr)
        {
            _genreSr = genreSr;
        }
        /// <summary>
        /// Выводит все жанры
        /// </summary>
        [HttpGet]
        public IQueryable<Book> GetAllGenres()
        {
            return _genreSr.GetGenreList();
        }

        /// <summary>
        /// Выводит статистику Жанр - количество книг
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetGenreCountBooks(int genreId)
        {
            _genreSr.GetGenreCountBooks(genreId);
             return Ok();
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] Genre genre)
        {
            _genreSr.Create(genre);
            return Ok();
        }
    }
}
