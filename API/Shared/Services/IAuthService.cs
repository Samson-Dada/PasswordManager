using API.Shared.Models.UserDto;

namespace API.Shared.Services
{
    public interface IAuthService
    {
        Task<(int, string)> Registration( UserForSignupDto userForSignupDto, string role);
        Task<(int, string)> Login(UserForLoginDto userForLoginDto);
    }
}
