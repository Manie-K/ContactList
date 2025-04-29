using System.ComponentModel.DataAnnotations;

namespace ContactListAPI.Models
{
    /// <summary>
    /// Represents a user account in the system.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        [MinLength(2)]
        public required string Name { get; set; }
        
        [EmailAddress]
        public required string Email { get; set; }
        public required byte[] HashedPassword { get; set; }
        public required byte[] Salt { get; set; } 
    }
}
