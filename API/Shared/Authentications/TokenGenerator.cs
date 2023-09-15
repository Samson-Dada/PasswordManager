using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Shared.Authentications
{
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;

        //public TokenGenerator(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public  string GenerateToken(List<Claim> claims)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWTKey:SecretKey"]);

            SymmetricSecurityKey securityKey = new(key);

            var tokenExpiryTimeout = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeout"]);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Issuer = _configuration["JWTKey:Issuer"],
                Audience = _configuration["JWTKey:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTimeout),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims),
            };
            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string writeToken = tokenHandler.WriteToken(token);
            return writeToken;
        }

       
    }
}
