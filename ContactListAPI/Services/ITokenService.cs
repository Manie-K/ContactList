using ContactListAPI.Models;

namespace ContactListAPI.Services
{
    /// <summary>
    /// Service for managing authentication tokens.
    /// </summary>
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
