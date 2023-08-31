using System.ComponentModel.DataAnnotations;

namespace API.Shared.Models.UserDto
{
    public class UserForSignupDto
    {

        [MinLength(3, ErrorMessage = "Username is to short")]
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [MinLength(8, ErrorMessage = "Password is to short")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string UserPassword { get; set; }

        [MinLength(8, ErrorMessage = "Email is to short")]
        [Required(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
