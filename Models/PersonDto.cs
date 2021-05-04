using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Library.Models
{
    public class PersonDto
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public DateTime BirthDay { get; set; } 
    }
 
}
