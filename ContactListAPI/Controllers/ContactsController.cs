﻿using ContactListAPI.DTO;
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
        public async Task<ActionResult<List<GetContactBasicDTO>>> GetAllContacts()
        {
            List<GetContactBasicDTO> res = (await _contactService.GetAllContactsAsync()).ToList();
            return res;
        }

        /// <summary>
        /// Returns a single contact with given id.
        /// <paramref name="id">Id of the contact to get.</paramref>
        /// </summary>
        // GET: api/Contacts/id
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetContactDetailsDTO>> GetContactById(int id)
        {
            GetContactDetailsDTO? res = await _contactService.GetContactByIdAsync(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        /// <summary>
        /// Creates a contact with given data. Authorization is required.
        /// <paramref name="dto"> Dto of a contact to create.</paramref>
        /// </summary>
        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<GetContactDetailsDTO>> CreateContact([FromBody] CreateContactDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            GetContactDetailsDTO? createdDto = await _contactService.AddContactAsync(dto);
            if (createdDto == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetContactById), new { id = createdDto.Id }, createdDto);
        }

        /// <summary>
        /// Updates a given contact with given data. Authorization is required.
        /// <paramref name="dto"> Dto with new data.</paramref>
        /// <paramref name="id"> Id of the contact to update.</paramref>
        /// </summary>
        // PUT: api/Contacts/id
        [HttpPut("{id}")]
        public async Task<ActionResult<GetContactDetailsDTO>> UpdateContact(int id, [FromBody] UpdateContactDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            GetContactDetailsDTO? updatedDto = await _contactService.UpdateContactAsync(id, dto);
            if (updatedDto == null)
            {
                return NotFound();
            }

            return updatedDto;
        }


        /// <summary>
        /// Deletes a contact with given id. Authorization is required.
        /// <paramref name="id"> Id of the contact to delete.</paramref>
        /// </summary>
        // DELETE: api/Contacts/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            bool deleted = await _contactService.DeleteContactAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
