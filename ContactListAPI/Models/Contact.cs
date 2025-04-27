namespace ContactListAPI.Models
{
    public class Contact
    {
        //TODO: Add constraints and validation
        public int Id { get; set; } //PK
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; } //Unique
        //public required string Password { get; set; } //Should it be here or is there a mistake in instruction?
        public required string Category { get; set; }
        public string? Subcategory { get; set; }
        public required string Phone { get; set; }
        public required DateTime DateOfBirth { get; set; }
    }
}
