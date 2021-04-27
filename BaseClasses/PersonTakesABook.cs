using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject
{
    public class PersonTakesABook
    {
        [Required]
        public static PersonDto personTaking { get; set; }

        [Required]
        public static BookDto bookTaken { get; set; }

        [Required]
        public static DateTimeOffset bookDateTimeOffset { get; set; }

        PersonTakesABook _personTakesABook;
        public PersonTakesABook()
        {
            _personTakesABook = new PersonTakesABook();
        }
    }

    
}
