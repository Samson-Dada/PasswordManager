using System.ComponentModel.DataAnnotations;

namespace API.Shared.Models.AdminDto
{
    public class AdminForSignupDto
    {

        [MinLength(3, ErrorMessage = "Username is to short")]
        [Required(ErrorMessage = "Please Enter Username")]
        public string UserName { get; set; }

        [MinLength(5, ErrorMessage = "Password is to short")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [MinLength(5, ErrorMessage = "Email is to short")]
        [Required(ErrorMessage = "Invalid Email Address")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
