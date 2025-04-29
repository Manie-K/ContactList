using System.ComponentModel.DataAnnotations;
using ContactListAPI.Validation;

namespace ContactListAPI.DTO
{
    /// <summary>
    /// DTO used in the POST request to create a new contact.
    /// </summary>
    public class CreateContactDTO
    {
        [MinLength(2)]
        public required string FirstName { get; set; }
        [MinLength(2)]
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [PasswordValidation]
        public required string Password { get; set; } //TODO: validation + hashing
        public required string Category { get; set; }
        public required string? Subcategory { get; set; }
        [Phone]
        public required string Phone { get; set; }
        public required DateOnly DateOfBirth { get; set; }
    }
}
