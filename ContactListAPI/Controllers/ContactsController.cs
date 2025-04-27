using ContactListAPI.Data;
using ContactListAPI.DTO;
using ContactListAPI.Models;
using ContactListAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<List<GetContactDTO>>> GetAllContacts()
        {
            List<GetContactDTO> res = (await _contactService.GetAllContacts()).ToList();
            return res;
        }

        // GET: api/Contacts/id
        [HttpGet("{id}")]
        public async Task<ActionResult<GetContactDTO>> GetContactById(int id)
        {
            GetContactDTO? res = await _contactService.GetContactById(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<GetContactDTO>> CreateContact([FromBody] CreateContactDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            GetContactDTO createdDto = await _contactService.AddContact(dto);
            return CreatedAtAction(nameof(GetContactById), new { id = createdDto.Id }, createdDto);
        }

        // PUT: api/Contacts/id
        [HttpPut("{id}")]
        public async Task<ActionResult<GetContactDTO>> UpdateContact(int id, [FromBody] UpdateContactDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            GetContactDTO? updatedDto = await _contactService.UpdateContact(id, dto);
            if (updatedDto == null)
            {
                return NotFound();
            }

            return updatedDto;
        }

        // DELETE: api/Contacts/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            bool deleted = await _contactService.DeleteContact(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
