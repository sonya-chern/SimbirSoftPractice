using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Library.Models
{
    public class GenreDto
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        public string GenreName { get; set; }

        [NotMapped]
        public ICollection<BookDto> Books { get; set; }

        public GenreDto()
        {
            Books = new List<BookDto>();
        }
    }
}
