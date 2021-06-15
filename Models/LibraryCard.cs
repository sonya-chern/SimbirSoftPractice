using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WebApplication.Library.Models
{
    [Table("library_cards")]
    public class LibraryCard
    {
        [Key]
        public int LibraryCardId { get; set; }

        [Required]
        public static DateTimeOffset BookTakenDate { get; set; }

        /// <summary>
        /// 2.2 свойство для создания связи м/у таблицами Books-LibraryCards
        /// </summary>
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        /// <summary>
        /// 2.2 свойство для создания связи м/у таблицами People-LibraryCards
        /// </summary>
        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }

        public virtual Person APerson { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public LibraryCard()
        {
            Books = new List<Book>();
        }
    }   
}
