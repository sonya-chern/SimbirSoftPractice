using System.ComponentModel.DataAnnotations;

namespace WebApplication.Library.ModelsDTO
{
    public class BookDto
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public PersonDto BooksAuthor { get; set; }
       
    }

    
}
