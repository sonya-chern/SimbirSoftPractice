using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        public static List<PersonDto> listPersons = new List<PersonDto>(3);
        
        [HttpGet]
        public IEnumerable<PersonDto> GetPersons()
        {
            return listPersons;
        }

        public IEnumerable<PersonDto> GetPersonByName(string name)
        {
            foreach (var item in listPersons)
            {
                if (item.firstName == name)
                    yield return item;
            }

        }

        [HttpPost]
        public List<PersonDto> AddPerson([FromBody]PersonDto person)
        {
            listPersons.Add(person);
            return listPersons;

        }

        public IActionResult DeletePerson(string lastN, string firstN, string patron)
        {
            try
            {
                foreach (var item in listPersons)
                {
                    if (item.lastName == lastN && item.firstName == firstN && item.patronymic == patron) listPersons.Remove(item);
                }
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
