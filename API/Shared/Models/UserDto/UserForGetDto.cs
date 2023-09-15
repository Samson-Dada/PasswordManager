using API.Shared.Entities;
using API.Shared.Models.PasswordDto;

namespace API.Shared.Models.UserDto
{
    public record UserForGetDto
    {
        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string UserPassword { get; init; }
        public ICollection<PasswordForGetDto> Password { get; init; }
    }
}