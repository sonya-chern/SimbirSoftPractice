using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WebApplication.Library.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public DateTimeOffset BirthDay { get; set; }

        /// <summary>
        /// 2.2 свойство для создания связи м/у таблицами
        /// </summary>
        [NotMapped]//другой аттрибут
        public LibraryCard APerson { get; set; }

        public ICollection<Book> Books { get; set; }

        public Person()
        {
            Books = new List<Book>();
        }
    }
}
