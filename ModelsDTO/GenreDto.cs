using System.ComponentModel.DataAnnotations;

namespace WebApplication.Library.ModelsDTO
{
    public class GenreDto
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        public string GenreName { get; set; }
    }
}
