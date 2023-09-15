using API.Shared.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Shared.Models.PasswordDto
{
    public record PasswordForGetDto
    {
        public string Title { get; set; }
        public string HashedPassword { get; set; }
        //public string UserId { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
