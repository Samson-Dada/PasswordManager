using API.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Shared.Models.UserDto
{
    public class UserForUpdateDto1
    {

        public UserForUpdateDto1()
        {
            Password = new List<Password>();
        }

        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Username is to short")]
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [MinLength(8, ErrorMessage = "Password is to short")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string UserPassword { get; set; }

        [MinLength(8, ErrorMessage = "Email is to short")]
        [Required(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public ICollection<Password> Password { get; set; }
    }
}
