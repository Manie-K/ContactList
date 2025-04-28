using ContactListAPI.DTO;
using ContactListAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactListAPI.Controllers
{
    /// <summary>
    /// Controller for managing contacts.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }


        /// <summary>
        /// Returns a list of all contacts.
        /// </summary>
        // GET: api/Contacts
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetContactDTO>>> GetAllContacts()
        {
            List<GetContactDTO> res = (await _contactService.GetAllContacts()).ToList();
            return res;
        }

        /// <summary>
        /// Returns a single contact with given id.
        /// <paramref name="id"/>Id of the contact to get.</paramref>
        /// </summary>
        // GET: api/Contacts/id
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetContactDTO>> GetContactById(int id)
        {
            GetContactDTO? res = await _contactService.GetContactById(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        /// <summary>
        /// Creates a contact with given data. Authorization is required.
        /// <paramref name="dto"/> Dto of a contact to create.</paramref>
        /// </summary>
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

        /// <summary>
        /// Updates a given contact with given data. Authorization is required.
        /// <paramref name="dto"/> Dto with new data.</paramref>
        /// <paramref name="id"/> Id of the contact to update.</paramref>
        /// </summary>
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


        /// <summary>
        /// Deletes a contact with given id. Authorization is required.
        /// <paramref name="id"/> Id of the contact to delete.</paramref>
        /// </summary>
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
