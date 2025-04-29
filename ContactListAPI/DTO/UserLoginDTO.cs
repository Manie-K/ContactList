using System.ComponentModel.DataAnnotations;
using ContactListAPI.Validation;

namespace ContactListAPI.DTO
{
    public class UserLoginDTO
    {
        [EmailAddress]
        public required string Email { get; set; }
        [PasswordValidation]
        public required string Password { get; set; }
    }
}
