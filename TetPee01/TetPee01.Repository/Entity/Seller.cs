using TetPee01.Repository.Abtraction;

namespace TetPee01.Repository.Entity;

public class Seller: BaseEntity<Guid>, IAudictableEntity 
{
    
    public string TaxCode { get; set; }
    public string CompanyName { get; set; }
    public string CompanayAdress  { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    //Seller với user
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    //Seller với Product
    public ICollection<Product>  Products { get; set; } = new  List<Product>();
    
}