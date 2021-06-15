using WebApplication.Library.Models;
using WebApplication.Library.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication.Library.Services
{
    public class BookService : ILibraryService<Book>
    {
        private readonly BookRepository _bookRp;

        public BookService(BookRepository bookRp)
        {
            _bookRp = bookRp;
        }

        /// <summary>
        /// Проверить есть ли книга
        /// </summary>
        public bool FindById(int bookId)
        {
            Book book = _bookRp.GetBook(bookId);
            return (book != null);
        }

        /// <summary>
        /// Выводит список всех книг автора(автор-книги-жанры)
        /// </summary>
        public IQueryable<Book> GetBooksByAuthor(int authorId)
        {
            return _bookRp.GetBooksByAuthor(authorId);
        }

        /// <summary>
        /// Выводит список всех книг по жанру(жанр+книги)
        /// </summary>
        public IQueryable<Book> GetBooksByGenre(Genre genre)
        {
            return _bookRp.GetBooksByGenre(genre);
        }

        /// <summary>
        /// Создает объекты
        /// </summary>
        public IActionResult Create(Book book)
        {
            if (_bookRp.Create(book)) 
            {
                return new OkObjectResult("Книга добавлена");
            }
            else return new NotFoundObjectResult("Ошибка добавления");
        }

        /// <summary>
        /// Изменяет жанр/жанры у книги
        /// </summary>
        public void Update(Book newBook)
        {
            FindById(newBook.BookId);
            _bookRp.UpdateGenre(newBook);
        }

        /// <summary>
        /// Удаляет книгу по ID, только если она не у пользователя
        /// </summary>
        public IActionResult Delete(int bookId)
        {
            FindById(bookId);
            Book book = _bookRp.GetBook(bookId);
            if (book.AuthorId == 0)
            {
                _bookRp.DeleteById(bookId);
                return new OkObjectResult("книга удалена");
            }
            else return new NotFoundObjectResult("Книга находится у пользователя");
        }
    }
}
