using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;
using System.Collections.Generic;


namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PersonsController : ControllerBase
    {
        public static List<PersonDto> listPersons = new List<PersonDto>();
        
        [HttpGet]
        public IEnumerable<PersonDto> GetPersons()
        {
            return listPersons;
        }

        /// <summary>
        /// 1.2.2 метод возвращающий список людей по имени
        /// </summary>
        [HttpGet]
        public IEnumerable<PersonDto> GetPersonByName(string name)
        {
            return listPersons.FindAll(item => item.FirstName == name);
        }

        [HttpPost(template:"post")]
        public List<PersonDto> AddPerson([FromBody]PersonDto person)
        {
            listPersons.Add(person);
            return listPersons;
        }

        [HttpDelete]
        public IActionResult DeletePerson(string lastN, string firstN, string patron)
        {
            foreach (var item in listPersons)
            {
                if (item.LastName == lastN && item.FirstName == firstN && item.Patronymic == patron)
                {
                    listPersons.Remove(item);
                }
            }
            return Ok();
        }
    }
}
