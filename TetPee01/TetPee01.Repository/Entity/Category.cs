using TetPee01.Repository.Abtraction;

namespace TetPee01.Repository.Entity;

public class Category: BaseEntity<Guid>, IAudictableEntity
{
    
    public required string  Name { get; set; }
  

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    public ICollection<Category> ChildCategories { get; set; } = new  List<Category>();
    
    public ICollection<Product_Category> Product_Category { get; set; } = new  List<Product_Category>();
}