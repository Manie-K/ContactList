using ContactListAPI.Data;
using ContactListAPI.DTO;
using ContactListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactListDataContext _context;

        public ContactService(ContactListDataContext context)
        {
            _context = context;
        }

        private GetContactDTO ContactToDTO(Contact contact) =>
            new GetContactDTO
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Category = contact.Category,
                Subcategory = contact.Subcategory,
                Phone = contact.Phone,
                DateOfBirth = contact.DateOfBirth
            };

        public async Task<IEnumerable<GetContactDTO>> GetAllContactsAsync()
        {
            IEnumerable<Contact> contacts = await _context.Contacts.ToListAsync();
            IEnumerable<GetContactDTO> dtos = contacts.Select(ContactToDTO);
            return dtos;
        }

        public async Task<GetContactDTO?> GetContactByIdAsync(int id)
        {
            Contact? contact = await _context.Contacts.FindAsync(id);
            GetContactDTO? dto = contact == null ? null : ContactToDTO(contact);
            return dto;
        }

        public async Task<GetContactDTO> AddContactAsync(CreateContactDTO dto)
        {
            Contact contact = new Contact
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Category = dto.Category,
                Subcategory = dto.Subcategory,
                Phone = dto.Phone,
                DateOfBirth = dto.DateOfBirth
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return ContactToDTO(contact);
        }

        public async Task<GetContactDTO?> UpdateContactAsync(int id, UpdateContactDTO dto)
        {
            Contact? contact = await _context.Contacts.FindAsync(id);
            if(contact == null)
            {
                return null;
            }

            contact.FirstName = dto.FirstName;
            contact.LastName = dto.LastName;
            //contact.Email = dto.Email;
            contact.Category = dto.Category;
            contact.Subcategory = dto.Subcategory;
            contact.Phone = dto.Phone;
            contact.DateOfBirth = dto.DateOfBirth;

            await _context.SaveChangesAsync();
            return ContactToDTO(contact);
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            Contact? contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
         
            return true;
        }
    }
}
