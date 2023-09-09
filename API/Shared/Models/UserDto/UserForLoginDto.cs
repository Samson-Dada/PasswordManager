using System.ComponentModel.DataAnnotations;

namespace API.Shared.Models.UserDto
{
    public class UserForLoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
