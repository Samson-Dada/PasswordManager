using API.Shared.Entities;
using API.Shared.Models.PasswordDto;

namespace API.Shared.Models.UserDto
{
    public class UserForGetDto
    {
        public UserForGetDto()
        {
            Password = new List<PasswordForGetDto>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public ICollection<PasswordForGetDto> Password { get; set; }
    }
}
