using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject
{
    public class PersonDto
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string lastName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string firstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string patronymic { get; set; }

        [Required]
        public DateTime birthDay { get; set; } 
    }
 
}
