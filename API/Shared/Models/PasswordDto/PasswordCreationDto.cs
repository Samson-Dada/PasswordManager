using System.ComponentModel.DataAnnotations;

namespace API.Shared.Models.PasswordDto
{
    public class PasswordCreationDto
    {
        [MinLength(8)]
        [Required]
        public string Title { get; set; }

        [MinLength(5)]
        [Required]
        public string HashedPassword { get; set; }
        public string Date { get; set; }
    }
}
