using TetPee01.Repository.Abtraction;

namespace TetPee01.Repository.Entity;

public class Product: BaseEntity<Guid>, IAudictableEntity 
{
    public string Name  { get; set; }
    public string Description  { get; set; }
    public string UrlImage  { get; set; }
    public decimal Price     { get; set; }
    
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    //Product với Seller
    public Guid SellerId { get; set; }
    public Seller Seller { get; set; }
    
    //Product với Product_Category
    public ICollection<Product_Category>  Product_Category { get; set; } = new  List<Product_Category>();
    
}