namespace ContactListAPI.DTO
{
    /// <summary>
    /// DTO used in the POST request to create a new contact.
    /// </summary>
    public class CreateContactDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Category { get; set; }
        public string? Subcategory { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
