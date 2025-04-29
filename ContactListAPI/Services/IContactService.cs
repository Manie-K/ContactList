using ContactListAPI.DTO;
using ContactListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Services
{
    public interface IContactService
    {
        public Task<IEnumerable<GetContactBasicDTO>> GetAllContactsAsync();
        public Task<GetContactDetailsDTO?> GetContactByIdAsync(int id);
        public Task<GetContactDetailsDTO?> AddContactAsync(CreateContactDTO dto);
        public Task<GetContactDetailsDTO?> UpdateContactAsync(int id, UpdateContactDTO dto);
        public Task<bool> DeleteContactAsync(int id);
    }
}
