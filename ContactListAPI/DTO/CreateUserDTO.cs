using System.ComponentModel.DataAnnotations;
using ContactListAPI.Validation;
using ContactListAPI.Controllers;

namespace ContactListAPI.DTO
{
    /// <summary>
    /// DTO used in the POST request to <see cref="AuthController"/> to register a new user.
    /// </summary>
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
