using ContactListAPI.DTO;
using ContactListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Services
{
    public interface IContactService
    {
        public Task<IEnumerable<GetContactDTO>> GetAllContacts();
        public Task<GetContactDTO?> GetContactById(int id);
        public Task<GetContactDTO> AddContact(CreateContactDTO dto);
        public Task<GetContactDTO?> UpdateContact(int id, UpdateContactDTO dto);
        public Task<bool> DeleteContact(int id);
    }
}
