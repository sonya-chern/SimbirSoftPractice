using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Library.Models
{
    public class BookDto
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public AuthorDto BooksAuthor { get; set; }

        /// <summary>
        /// 2.2 свойство для создания связи м/у таблицами
        /// </summary>
        [NotMapped]
        public LibraryCard ABook { get; set; }
        [NotMapped]
        public ICollection<GenreDto> Genres { get; set; }

        public BookDto()
        {
            Genres = new List<GenreDto>();
        }
    } 
}
