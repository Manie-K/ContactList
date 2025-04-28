using System.Text;
using ContactListAPI.DTO;
using ContactListAPI.Models;
using ContactListAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] UserLoginDTO dto)
        {
            User? user = await _userService.GetUserByEmailAsync(dto.Email);
            if (user == null)
            {
                return NotFound("User not found");
            }
            using var hmac = new System.Security.Cryptography.HMACSHA256(user.Salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));

            if (!computedHash.SequenceEqual(user.HashedPassword))
            {
                return Unauthorized("Invalid password");
            }

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDTO>> RegisterAsync(CreateUserDTO dto)
        {
            if(await _userService.GetUserByEmailAsync(dto.Email) != null)
            {
                return BadRequest("User with such email already exists!");
            }

            User user = await _userService.AddUserAsync(dto);

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
