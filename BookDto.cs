using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject
{
    public class BookDto
    {
        private string bookTitle;
        PersonDto authorName;
        private string booksGenre;
        public static List<BookDto> listBooks = new List<BookDto>(3);
    }

    
}
