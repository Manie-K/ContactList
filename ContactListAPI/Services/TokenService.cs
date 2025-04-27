using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactListAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace ContactListAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Generates a JWT token for the given user.
        /// <paramref name="user"/>User which receives token.</paramred>
        /// <returns>JWT token as a string.</returns>
        /// </summary>
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
