using System.ComponentModel.DataAnnotations;

namespace ContactListAPI.Validation
{
    public class PasswordValidationAttribute:ValidationAttribute
    {
        private const int MinLength = 8;

        /// <summary>
        /// Ensured that the password passes all modern security requirenments.
        /// </summary>
        public override bool IsValid(object? value)
        {
            var password = value as string;
            if(string.IsNullOrEmpty(password))
            {
                return false;
            }

            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

            return password.Length >= MinLength && hasUpper && hasLower && hasDigit && hasSpecial;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be at least {MinLength} characters long and contain upper and lowercase letters, " +
                $"digits, and a special character.";
        }
    }
}
