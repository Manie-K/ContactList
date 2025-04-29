using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using ContactListAPI.Data;
using ContactListAPI.DTO;
using ContactListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactListDataContext _context;
        private readonly IMapper _mapper;

        public ContactService(ContactListDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetContactBasicDTO>> GetAllContactsAsync()
        {
            IEnumerable<Contact> contacts = await _context.Contacts.ToListAsync();
            IEnumerable<GetContactBasicDTO> dtos;
            /*dtos = contacts.Select(c => new GetContactBasicDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email
            });*/
            dtos = contacts.Select(_mapper.Map<GetContactBasicDTO>);
            return dtos;
        }

        public async Task<GetContactDetailsDTO?> GetContactByIdAsync(int id)
        {
            Contact? contact = await _context.Contacts.FindAsync(id);
            GetContactDetailsDTO? dto = contact == null ? null : _mapper.Map<GetContactDetailsDTO>(contact);
            return dto;
        }

        public async Task<GetContactDetailsDTO?> AddContactAsync(CreateContactDTO dto)
        {
            bool emailTaken = false;
            var allContacts = await _context.Contacts.ToListAsync();
            allContacts.Select(c => c.Email).ToList().ForEach(email =>
            {
                if (email == dto.Email)
                {
                    emailTaken = true;
                }
            });
            if (emailTaken)
            {
                return null;
            }

            using var hmac = new System.Security.Cryptography.HMACSHA256();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            var salt = hmac.Key;

            Contact contact = new Contact
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = hash, 
                PasswordSalt = salt,
                Category = dto.Category,
                Subcategory = dto.Subcategory,
                Phone = dto.Phone,
                DateOfBirth = dto.DateOfBirth
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetContactDetailsDTO>(contact);
        }

        public async Task<GetContactDetailsDTO?> UpdateContactAsync(int id, UpdateContactDTO dto)
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
            return _mapper.Map<GetContactDetailsDTO>(contact);
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
