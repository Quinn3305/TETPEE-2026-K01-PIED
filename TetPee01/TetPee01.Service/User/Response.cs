namespace TetPee01.Service.User;

public class Response
{
    public class GetUserResponse
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? DateOfBirth  { get; set; }
        public string? UrlImage { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = "User";
    }
}