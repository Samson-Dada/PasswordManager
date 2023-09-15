using API.Shared.Authentications;
using API.Shared.Entities;
using API.Shared.Models;
using API.Shared.Models.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Shared.Authentications.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }
        public async Task<(int, string)> Login(UserForLoginDto userForLoginDto)
        {

            var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
            if (user == null)
                return (0, "Invalid username");
            if (!await _userManager.CheckPasswordAsync(user, userForLoginDto.Password))
                return (0, "Invalid password");

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
              new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string token = GenerateToken(authClaims);
            return (1, token);
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();

        }
        public async Task<(int, string)> Registration(UserForSignupDto userForSignupDto, string role)
        {

            var userExists = await _userManager.FindByNameAsync(userForSignupDto.UserName);
            if (userExists != null)
                return (0, "User already exists");

            User user = new()
            {
                FirstName = userForSignupDto.FirstName,
                LastName = userForSignupDto.LastName,
                Email = userForSignupDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userForSignupDto.UserName
            };
            var createUserResult = await _userManager.CreateAsync(user, userForSignupDto.UserPassword);
            if (!createUserResult.Succeeded)
                return (0, "User creation failed! Please check user details and try again.");

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            if (await _roleManager.RoleExistsAsync(role))
                await _userManager.AddToRoleAsync(user, role);

            return (1, "User created successfully!");
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["jWTKey:SecretKey"]);
            var authSignKey = new SymmetricSecurityKey(key);

            var tokenExpiryTimeout = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeout"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWTKey:Issuer"],
                Audience = _configuration["JWTKey:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTimeout),
                SigningCredentials = new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
