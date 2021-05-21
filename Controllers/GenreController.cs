using WebApplication.Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;

namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GenreController : ControllerBase
    {
        private readonly GenreRepository _genreRp;

        public GenreController(GenreRepository genreRp)
        {
            _genreRp = genreRp;
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var allGenres = _genreRp.GetGenreList();
            return Ok(allGenres);
        }

        /// <summary>
        /// Вывод статистики Жанр - количество книг
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetGenreCountBooks(int genreId)
        {
            var genre = _genreRp.GetGenre(genreId);
            if (genre != null)
            {
                var allGenreCountBooks = _genreRp.GetGenreNumberBooks(genre);
                return Ok(allGenreCountBooks);
            }
            else return NotFound("Жанр не найден");

        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] Genre genre)
        {
            _genreRp.Create(genre);
            _genreRp.Save();
            return Ok("Жанр добавлен");
        }


    }
}
