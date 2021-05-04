using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Library.Models
{
    public class PersonTakesABook
    {
        [Required]
        public static PersonDto PersonTaking { get; set; }

        [Required]
        public static BookDto BookTaken { get; set; }

        [Required]
        public static DateTimeOffset BookDateTimeOffset { get; set; }

        public PersonTakesABook personTakesABook;
        public PersonTakesABook()
        {
            personTakesABook = new PersonTakesABook();
        }
    }

    
}
