using System.ComponentModel.DataAnnotations;

namespace API.Shared.Models.PasswordDto
{
    public record PasswordCreationDto
    {
        [MinLength(8, ErrorMessage = "Title is too short")]
        [Required]
        public string Title { get; set; }

        [MinLength(5, ErrorMessage = "password is too short ")]
        [Required]
        public string HashedPassword { get; set; }
        public string Date { get; set; }
    }
}
