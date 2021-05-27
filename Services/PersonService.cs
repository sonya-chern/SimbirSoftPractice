using WebApplication.Library.Models;
using WebApplication.Library.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Library.Services
{
    public class PersonService : ILibraryService<Person>
    {
        private readonly PersonRepository _personRp;

        public PersonService(PersonRepository personRp)
        {
            _personRp = personRp;
        }

        /// <summary>
        /// Проверяет есть ли пользователь
        /// </summary>
        public bool GetById(int personId)
        {
            Person person = _personRp.GetPerson(personId);
            return (person != null);
        }

        /// <summary>
        /// Показывает взятые пользователем книги(Книги - автор - жанр)
        /// </summary>
        public IActionResult GetBookByPersonId(int personId)
        {
            if (GetById(personId))
            {
                var result = _personRp.GetBookByPersonId(personId);
                return new OkObjectResult(result);
            }
            else return new NotFoundObjectResult("Пользователь с данным ID не найден");
        }

        /// <summary>
        /// Добавляет книгу в карточку пользователя
        /// </summary>
        public IActionResult PersonTakesBook(int personId, Book book)
        {
            if (GetById(personId))
            {
                _personRp.AddBook(personId, book);
                return new OkObjectResult("Книга добавлена в карточку пользователя");
            }
            else return new NotFoundObjectResult("Пользователь с данным ID не найден");
        }

        /// <summary>
        /// Изменяет данные о пользователе
        /// </summary>
        public void Update(Person person)
        {
            if (GetById(person.PersonId))
            {
                _personRp.Update(person);
            }
        }

        /// <summary>
        /// Добавляет данные о пользователе
        /// </summary>
        public IActionResult Create(Person person)
        {
            if (GetById(person.PersonId))
            {
                _personRp.Create(person);
                return new OkObjectResult("Пользователь добавлен");
            }
            else return new NotFoundObjectResult("Ошибка добавления");
        }

        /// <summary>
        /// Удаляет пользователя по ID
        /// </summary>
        public IActionResult Delete(int personId)
        {
            if (GetById(personId))
            {
                _personRp.Delete(personId);
                return new OkObjectResult("Пользователь удален");
            }
            else return new NotFoundObjectResult("Пользователь с данным ID не найден");
        }

        public IActionResult DeleteByName(Person newPerson)
        {
            if (GetById(newPerson.PersonId))
            {
                _personRp.DeleteByName(newPerson);
                return new OkObjectResult("Пользователь удален");
            }
            else return new NotFoundObjectResult("Пользователь с данным ID не найден");
        }

        /// <summary>
        /// Удаляет книгу из списка книг пользователя
        /// </summary>
        public IActionResult DeleteBook(int personId, Book book)
        {
            if (GetById(personId))
            {
                _personRp.DeleteBook(personId, book);
                return new OkObjectResult("Книга удалена из списка книг пользователя");
            }
            else return new NotFoundObjectResult("Пользователь с данным ID не найден");
        }
    }
}
