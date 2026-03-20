namespace TetPee01.Repository.Abtraction;

public interface IAudictableEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}