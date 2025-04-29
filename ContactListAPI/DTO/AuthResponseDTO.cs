namespace ContactListAPI.DTO
{
    /// <summary>
    /// DTO for the authentication response.
    /// </summary>
    public class AuthResponseDTO
    {
        public required string Name { get; set; }
        public required string Token { get; set; }
    }
}
