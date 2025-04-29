using System.ComponentModel.DataAnnotations;
using ContactListAPI.Controllers;
using ContactListAPI.Validation;

namespace ContactListAPI.DTO
{
    /// <summary>
    /// DTO used in the POST request to <see cref="AuthController"/> to login.
    /// </summary>
    public class UserLoginDTO
    {
        [EmailAddress]
        public required string Email { get; set; }
        [PasswordValidation]
        public required string Password { get; set; }
    }
}
