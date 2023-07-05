using API.Entities;
using API.Models.PasswordDto;

namespace API.Models.UserDto
{
    public class UserForGetDto
    {
        public UserForGetDto() {
          Password = new List<PasswordForGetDto>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public ICollection<PasswordForGetDto> Password { get; set; }
    }
}
