using System.ComponentModel.DataAnnotations;

namespace ContactListAPI.DTO
{
    public class GetBasicContactDTO
    {
        public int Id { get; set; }
        [MinLength(2)]
        public required string FirstName { get; set; }
        [MinLength(2)]
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}
