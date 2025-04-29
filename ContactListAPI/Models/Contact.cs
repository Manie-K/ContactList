using System.ComponentModel.DataAnnotations;

namespace ContactListAPI.Models
{
    public class Contact
    {
        //TODO: Add constraints and validation
        public int Id { get; set; } //PK
        [MinLength(2)]
        public required string FirstName { get; set; }
        [MinLength(2)]
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; } //Unique
        public required byte[] PasswordHash { get; set; } //Technical requirement
        public required byte[] PasswordSalt { get; set; } 
        public required string Category { get; set; }
        public string? Subcategory { get; set; }
        [Phone]
        public required string Phone { get; set; }
        public required DateOnly DateOfBirth { get; set; }
    }
}
