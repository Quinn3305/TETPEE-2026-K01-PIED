using TetPee01.Repository.Abtraction;

namespace TetPee01.Repository.Entity;

public class User: BaseEntity<Guid>, IAudictableEntity
{
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public string? DateOfBirth  { get; set; }
    public string? ImageUrl  { get; set; }
    public string? PhoneNumber  { get; set; }
    public required string HashedPassword { get; set; }
    public string? Address { get; set; }
    public string Role { get; set; } = "User"; 
    public bool IsVerify { get; set; } = false;
    public int VerifyCode  { get; set; }


    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    //User Với Seller 
    public Seller? Seller { get; set; }
    
}