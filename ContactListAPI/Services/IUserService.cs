using ContactListAPI.DTO;
using ContactListAPI.Models;

namespace ContactListAPI.Services
{
    public interface IUserService
    {
        public Task<User?> GetUserByIdAsync(int id);
        public Task<User?> GetUserByEmailAsync(string email);
        public Task<User> AddUserAsync(CreateUserDTO dto);
    }
}
