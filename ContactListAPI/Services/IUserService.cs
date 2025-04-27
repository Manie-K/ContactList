using ContactListAPI.DTO;
using ContactListAPI.Models;

namespace ContactListAPI.Services
{
    public interface IUserService
    {
        public Task<User?> GetUserById(int id);
        public Task<User?> GetUserByEmail(string email);
        public Task<User> AddUser(CreateUserDTO dto);
    }
}
