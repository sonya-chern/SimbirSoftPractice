using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.BaseClasses
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonTakesABookController : ControllerBase
    {
        public static List<PersonTakesABook> listPersonsTakesABook = new List<PersonTakesABook>();

        [HttpPost]
        public List<PersonTakesABook> AddPerson([FromBody] PersonTakesABook personTakesABook)
        {
            listPersonsTakesABook.Add(personTakesABook);
            return listPersonsTakesABook;
        }
    }
}
