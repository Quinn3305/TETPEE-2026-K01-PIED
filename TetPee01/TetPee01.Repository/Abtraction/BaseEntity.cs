namespace TetPee01.Repository.Abtraction;

public abstract class BaseEntity<Tkey>
{
    public required Tkey  Id { get; set; }
    
    public bool IsDeleted { get; set; } = false;
    
}