namespace ContactListAPI.DTO
{
    /// <summary>
    /// DTO used in the PUT request to update a contact.
    /// </summary>
    public class UpdateContactDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; } //Assumtion: Email can't be updated
        public string Category { get; set; }
        public string? Subcategory { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
