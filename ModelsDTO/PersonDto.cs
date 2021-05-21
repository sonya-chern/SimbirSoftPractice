using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Library.ModelsDTO
{
    public class PersonDto
    {
        [Required]
        public int PersonId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public DateTimeOffset BirthDay { get; set; }
    }

    
}
