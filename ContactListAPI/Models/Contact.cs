using System.ComponentModel.DataAnnotations;

namespace ContactListAPI.Models
{
    /// <summary>
    /// Represents a contact in the system.
    /// </summary>
    public class Contact
    {
        public int Id { get; set; } 
        [MinLength(2)]
        public required string FirstName { get; set; }
        [MinLength(2)]
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required byte[] PasswordHash { get; set; } //Technical requirement
        public required byte[] PasswordSalt { get; set; } 
        public required string Category { get; set; }
        public string? Subcategory { get; set; }
        [Phone]
        public required string Phone { get; set; }
        public required DateOnly DateOfBirth { get; set; }
    }
}
