using ContactListAPI.DTO;
using ContactListAPI.Models;

namespace ContactListAPI.Services
{
    public interface IUserService
    {
        public Task<GetUserDTO?> GetUserById(int id);
        public Task<GetUserDTO?> GetUserByEmail(string email);
        public Task<User> AddUser(CreateUserDTO dto);
    }
}
