using WebApplication.Library.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;


namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PersonsController : ControllerBase
    {
        private readonly PersonService _personSr;

        public PersonsController(PersonService personSr)
        {
            _personSr = personSr;
        }

        /// <summary>
        /// Показывает взятые пользователем книги(Книги - автор - жанр)
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetPersonsBook(int personId)
        {
            var result = _personSr.GetBookByPersonId(personId);
            return Ok(result);
        }

        /// <summary>
        /// Добавляет книгу в карточку пользователя
        /// </summary>
        [HttpPut]
        public IActionResult PersonTakesBook([FromBody]int personId, Book book)
        {
            _personSr.PersonTakesBook(personId, book);
            return Ok();        
        }

        /// <summary>
        /// Изменяет данные о пользователе
        /// </summary>
        [HttpPut]
        public IActionResult ChangePerson(Person newPerson)
        {
            _personSr.Update(newPerson);
            return Ok();
        }

        /// <summary>
        /// Добавляет данные о пользователе
        /// </summary>
        [HttpPost]
        public Person AddPerson(Person person)
        {
            _personSr.Create(person);
            return person;
        }

        /// <summary>
        /// Удаляет пользователя по ID
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeletePersonById(int personId)
        { 
            _personSr.Delete(personId);
            return Ok();
        }

        /// <summary>
        /// Удаляет пользователя по ФИО
        /// </summary>
        [HttpDelete]
        public IActionResult DeletePersonByName(Person newPerson)
        {
            _personSr.DeleteByName(newPerson);
            return Ok();
        }

        /// <summary>
        /// Удаляет книгу из списка книг пользователя
        /// </summary>
        [HttpDelete]
        public IActionResult PersonReturnsBook(int personId, Book book)
        {
            _personSr.DeleteBook(personId, book);
            return Ok();
        }
    }
}
