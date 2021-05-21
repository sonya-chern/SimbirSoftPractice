using WebApplication.Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;


namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PersonsController : ControllerBase
    {
        private readonly PersonRepository _personRp;

        public PersonsController(PersonRepository personRp)
        {
            _personRp = personRp;
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonsBook(int personId)
        {
            Person newPerson = _personRp.GetPerson(personId);
            if (newPerson != null)
            {
                var result = _personRp.GetBookByPersonId(personId);
                return Ok(result);
            }
            else return NotFound("Пользователь с данным ID не найден");
        }

        [HttpPut]
        public IActionResult PersonTakesBook(int personId, Book book)
        {
            Person newPerson = _personRp.GetPerson(personId);
            if (newPerson != null)
            {
                _personRp.AddBook(personId, book);
                _personRp.Save();
                return Ok();
            }
            else return NotFound("Пользователь с данным ID не найден");
        }


        [HttpPut]
        public IActionResult ChangePerson(int personId, Person newPerson)
        {
            Person testPerson = _personRp.GetPerson(personId);
            if (testPerson != null)
            {
                var result = _personRp.Update(personId, newPerson);
                _personRp.Save();
                return Ok(result);
            }
            else return NotFound("Пользователь с данным ID не найден");
        }

        [HttpPost]
        public Person AddPerson(Person person)
        {
            _personRp.Create(person);
            _personRp.Save();
            return person;
        }

        [HttpDelete]
        public IActionResult DeletePersonById(int personId)
        {
            try
            {
                _personRp.Delete(personId);
                _personRp.Save();
                return Ok();
            }
            catch
            {
                return NotFound("Пользователь с данным ID не найден");
            }
        }

        [HttpDelete]
        public IActionResult DeletePersonByName(Person newPerson)
        {
            try
            {
                _personRp.DeleteByName(newPerson);
                _personRp.Save();
                return Ok();
            }
            catch
            {
                return NotFound("Ошибка удаления");
            }
        }

        [HttpDelete]
        public IActionResult PersonReturnsBook(int personId, Book book)
        {
            Person newPerson = _personRp.GetPerson(personId);
            if (newPerson != null)
            {
                _personRp.DeleteBook(personId, book);
                _personRp.Save();
                return Ok();
            }
            else return NotFound("Пользователь с данным ID не найден");
        }
    }
}
