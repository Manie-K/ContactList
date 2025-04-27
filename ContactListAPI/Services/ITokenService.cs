using ContactListAPI.Models;

namespace ContactListAPI.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
