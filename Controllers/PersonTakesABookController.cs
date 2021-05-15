using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;
using System.Collections.Generic;

namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PersonTakesABookController : ControllerBase
    {
        public static List<LibraryCard> listPersonsTakesABook = new List<LibraryCard>();

        [HttpPost]
        public List<LibraryCard> AddPerson([FromBody] LibraryCard personTakesABook)
        {
            listPersonsTakesABook.Add(personTakesABook);
            return listPersonsTakesABook;
        }
    }
}
