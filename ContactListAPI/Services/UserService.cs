using System.Text;
using ContactListAPI.Data;
using ContactListAPI.DTO;
using ContactListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ContactListDataContext _context;

        public UserService(ContactListDataContext context)
        {
            _context = context;
        }


        private GetUserDTO UserToDTO(User user)
        {
            return new GetUserDTO
            {
                Name = user.Name,
                Email = user.Email,
                HashedPassword = user.HashedPassword,
                Salt = user.Salt
            };
        }
        public async Task<GetUserDTO?> GetUserByEmail(string email)
        {
            User? user = await _context.Users.FirstOrDefaultAsync<User>(u => u.Email == email);
            if (user == null)
            {
                return null;
            }

            GetUserDTO dto = UserToDTO(user);
            return dto;
        }

        public async Task<GetUserDTO?> GetUserById(int id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync<User>(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            GetUserDTO dto = UserToDTO(user);
            return dto;
        }

        public async Task<User> AddUser(CreateUserDTO dto)
        {
            var hmac = new System.Security.Cryptography.HMACSHA256();

            User user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                HashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                Salt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return user;
        }
    }
}
