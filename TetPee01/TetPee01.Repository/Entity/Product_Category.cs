using TetPee01.Repository.Abtraction;

namespace TetPee01.Repository.Entity;

public class Product_Category: BaseEntity<Guid>, IAudictableEntity 
{
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    //Product_Cartegory với Product
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
    //Product_Cartegory với Category
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}