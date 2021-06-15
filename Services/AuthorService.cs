using WebApplication.Library.Models;
using WebApplication.Library.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Library.Services
{
    public class AuthorService : ILibraryService<Author>
    {
        private readonly IAuthorRepository _authorRp;

        public AuthorService(IAuthorRepository authorRp)
        {
            _authorRp = authorRp;
        }

        /// <summary>
        /// Проверяет есть ли автор
        /// </summary>
        public bool FindById(int authorId)
        {
            Author author = _authorRp.GetAuthor(authorId);
            return (author != null);
        }

        /// <summary>
        /// Возвращает список всех авторов
        /// </summary>
        public IQueryable<Author> GetAuthorList()
        {
            return (IQueryable<Author>)_authorRp.GetAuthorList();
        }

        /// <summary>
        /// Создает объекты
        /// </summary>
        public IActionResult Create(Author author)
        {
            if (_authorRp.Create(author))
            {
                return new OkObjectResult("Автор добавлен");
            }
            else return new NotFoundObjectResult("Ошибка добавления");
        }

        /// <summary>
        /// Изменяет данные автора
        /// </summary>
        public void Update(Author author)
        {
            if (FindById(author.AuthorId))
            {
                _authorRp.Update(author);
            }
        }

        /// <summary>
        /// Удаляет автора по ID, если нет книг
        /// </summary>
        public IActionResult Delete(int genreId)
        {
            if (FindById(genreId))
            {
                if (_authorRp.DeleteAuthor(genreId))
                {
                    return new OkObjectResult("Автор удален");
                }
                else return new NotFoundObjectResult("Нельзя удалить автора пока есть его книги");
            }
            else return new NotFoundObjectResult("Автор не найден");
        }

        /// <summary>
        /// Выводит список книг автора: автор + книги + жанры
        /// </summary>
        public IActionResult GetAuthorBook(int authorId)
        {
            if(FindById(authorId))
            {
                var allAuthorBook = _authorRp.GetBookList(authorId);
                return new ObjectResult(allAuthorBook);
            }
            else return new NotFoundObjectResult("Автор не найден");
        }
    }
}
