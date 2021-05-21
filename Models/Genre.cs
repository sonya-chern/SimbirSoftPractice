using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Library.Models
{
    [Table("dim_genres")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        public string GenreName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
