using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Library.Models
{
    public class LibraryCard
    {
        [Key]
        public int LibraryCardId { get; set; }

        [Required]
        public Book TakenBook { get; set; }

        [Required]
        public Person PersonTookBook { get; set; }

        [Required]
        public static DateTimeOffset BookTakenDate { get; set; }
    }   
}
