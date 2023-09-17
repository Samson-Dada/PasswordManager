using API.Shared.Models.AdminDto;
using API.Shared.Models.UserDto;
using System.Security.Claims;

namespace API.Shared.Authentications.Services
{
    public interface IAdminAuthService
    {
        //Task<(int, string)> Registration( UserForSignupDto userForSignupDto, string role);
        Task<(int, string)> Registration(AdminForSignupDto adminForSignupDto, string role);
        Task<(int, string)> Login(AdminForLoginDto adminForLoginDto);
        Task Logout();
        string GenerateToken(IEnumerable<Claim> claims);
    }
}