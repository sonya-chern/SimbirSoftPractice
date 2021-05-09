using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Library.Models
{
    public class BookDto
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string BookTitle { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string BooksGenre { get; set; }
    } 
}
