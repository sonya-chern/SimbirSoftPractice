using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Library.Models
{
    public class PersonDto
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
        [NotMapped]
        public LibraryCard APerson { get; set; }
    }
}
