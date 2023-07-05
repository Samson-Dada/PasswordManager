using API.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models.PasswordDto
{
    public class PasswordForGetDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        [Required]
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
