using System.ComponentModel.DataAnnotations;

namespace API.Shared.Models.AdminDto
{
    public class AdminForLoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
