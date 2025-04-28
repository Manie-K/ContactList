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

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            User? user = await _context.Users.FirstOrDefaultAsync<User>(u => u.Email == email);
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync<User>(u => u.Id == id);
            return user;
        }

        public async Task<User> AddUserAsync(CreateUserDTO dto)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA256();

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
