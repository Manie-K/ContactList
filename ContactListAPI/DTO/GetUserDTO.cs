namespace ContactListAPI.DTO
{
    public class GetUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] HashedPassword { get; set; }
        public byte[] Salt { get; set; }
    }
}
