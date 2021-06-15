using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Library.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public Author BooksAuthor { get; set; }

        /// 2.2 свойство для создания связи м/у таблицами
        /// </summary>
        [ForeignKey(nameof(LibraryCard))]
        public int AuthorId { get; set; }

        public virtual LibraryCard ABook { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public Book()
        {
            Genres = new List<Genre>();
        }
    } 
}
