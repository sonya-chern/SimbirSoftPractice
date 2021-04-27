using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject
{
    public class PersonTakesABook
    {
        public static PersonDto personTaking { get; set; }
        public static BookDto bookTaken { get; set; }
        public static DateTimeOffset bookDateTimeOffset { get; set; }

        PersonTakesABook _personTakesABook;
        public PersonTakesABook()
        {
            _personTakesABook = new PersonTakesABook();
        }
    }

    
}
