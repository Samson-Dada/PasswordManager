using API.Shared.Models.PasswordDto;
using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;

namespace API.Shared.Models.UserDto
{
    public class UserPasswordCreationDto
    {

        [MinLength(3, ErrorMessage = "Username is to short")]
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [MinLength(8, ErrorMessage = "Email is to short")]
        [Required(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Ignore]
        public ICollection<PasswordCreationDto> Password { get; set; }

        [MinLength(8, ErrorMessage = "User Password is to short")]
        [Required(ErrorMessage = "Please Enter User Password")]
        public string UserPassword { get; set; }
    }
}
