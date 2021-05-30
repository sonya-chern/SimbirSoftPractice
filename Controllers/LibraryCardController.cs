using Microsoft.AspNetCore.Mvc;
using WebApplication.Library.Models;
using WebApplication.Library.Services;

namespace WebApplication.Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class LibraryCardController : ControllerBase
    {
        private readonly LibraryCardService _libraryCardSr;

        public LibraryCardController(LibraryCardService libraryCardSr)
        {
            _libraryCardSr = libraryCardSr;
        }

        [HttpPost]
        public IActionResult AddCard([FromBody] LibraryCard libraryCard)
        {
            _libraryCardSr.Create(libraryCard);
            return Ok();
        }
    }
}
