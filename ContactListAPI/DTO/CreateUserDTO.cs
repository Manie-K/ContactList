using System.ComponentModel.DataAnnotations;
using ContactListAPI.Validation;

namespace ContactListAPI.DTO
{
    public class CreateUserDTO
    {
        [MinLength(2)]
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [PasswordValidation]
        public required string Password { get; set; }
    }
}
