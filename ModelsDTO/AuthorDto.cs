using System;
using System.ComponentModel.DataAnnotations;


namespace WebApplication.Library.ModelsDTO
{
    public class AuthorDto
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public DateTimeOffset BirthDay { get; set; }
    }
}
