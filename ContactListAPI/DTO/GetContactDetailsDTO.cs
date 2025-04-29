using System.ComponentModel.DataAnnotations;

namespace ContactListAPI.DTO
{
    /// <summary>
    /// DTO used to represent a contact in the response.
    /// </summary>
    public class GetContactDetailsDTO
    {
        public int Id { get; set; }
        [MinLength(2)]
        public required string FirstName { get; set; }
        [MinLength(2)]
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; } 
        public required string Category { get; set; }
        public string? Subcategory { get; set; }
        [Phone]
        public required string Phone { get; set; }
        public required DateOnly DateOfBirth { get; set; }
    }
}
