﻿using System.ComponentModel.DataAnnotations;
using ContactListAPI.Controllers;

namespace ContactListAPI.DTO
{
    /// <summary>
    /// DTO used in the PUT request to <see cref="ContactsController"/> to update an existing contact.
    /// </summary>
    public class UpdateContactDTO
    {
        [MinLength(2)]
        public required string FirstName { get; set; }
        [MinLength(2)]
        public required string LastName { get; set; }
        //public string Email { get; set; } //Assumption: Email can't be updated
        public required string Category { get; set; }
        public required string? Subcategory { get; set; }
        [Phone]
        public required string Phone { get; set; }
        public required DateOnly DateOfBirth { get; set; }
    }
}
