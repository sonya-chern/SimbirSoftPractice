using WebApplication.Library.Models;
using WebApplication.Library.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Library.Services
{
    public class GenreService : ILibraryService<Genre>
    {
        private readonly GenreRepository _genreRp;

        public GenreService(GenreRepository genreRp)
        {
            _genreRp = genreRp;
        }

        /// <summary>
        /// Проверяет есть ли жанр
        /// </summary>
        public bool FindById(int genreId)
        {
            Genre genre = _genreRp.GetGenre(genreId);
            return (genre != null);
        }

        /// <summary>
        /// Выводит список всех жанров
        /// </summary>
        public IQueryable<Book> GetGenreList()
        {
            return (IQueryable<Book>)_genreRp.GetGenreList();
        }

        /// <summary>
        /// Создает объекты
        /// </summary>
        public IActionResult Create(Genre genre)
        {
            if (_genreRp.Create(genre))
            {
                return new OkObjectResult("Жанр добавлен");
            }
            else return new NotFoundObjectResult("Ошибка добавления");
        }

        /// <summary>
        /// Изменяет название жанра
        /// </summary>
        public void Update(Genre newGenre)
        {
            FindById(newGenre.GenreId);
            _genreRp.Update(newGenre.GenreId, newGenre);
        }

        /// <summary>
        /// Удаляет жанр по ID
        /// </summary>
        public IActionResult Delete(int genreId)
        {
            try
            {
                FindById(genreId);
                _genreRp.Delete(genreId);
                return new OkObjectResult("Жанр удален");
            }
            catch
            {
                return new NotFoundObjectResult("Ошибка удаления");
            }
        }

        /// <summary>
        /// Выводит статистику Жанр - количество книг
        /// </summary>
        public IActionResult GetGenreCountBooks(int genreId)
        {
            var genre = _genreRp.GetGenre(genreId);
            if (genre != null)
            {
                var allGenreCountBooks = _genreRp.GetGenreNumberBooks(genre);
                return new OkObjectResult(allGenreCountBooks);
            }
            else return new NotFoundObjectResult("Жанр не найден");

        }
    }
}
