using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject
{
    public class BookDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string bookTitle { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string authorName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string booksGenre { get; set; }
    } 
}
