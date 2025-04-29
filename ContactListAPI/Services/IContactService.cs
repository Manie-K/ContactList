using ContactListAPI.DTO;
using ContactListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Services
{
    public interface IContactService
    {
        public Task<IEnumerable<GetBasicContactDTO>> GetAllContactsAsync();
        public Task<GetContactDTO?> GetContactByIdAsync(int id);
        public Task<GetContactDTO?> AddContactAsync(CreateContactDTO dto);
        public Task<GetContactDTO?> UpdateContactAsync(int id, UpdateContactDTO dto);
        public Task<bool> DeleteContactAsync(int id);
    }
}
