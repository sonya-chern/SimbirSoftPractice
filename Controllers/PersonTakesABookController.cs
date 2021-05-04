using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;
using System.Collections.Generic;

namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
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
