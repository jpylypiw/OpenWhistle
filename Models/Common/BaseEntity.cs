namespace OpenWhistle.Models;

public abstract class BaseEntity
{
    public Guid Id = Guid.NewGuid();
    public DateTime DateCreated = DateTime.UtcNow;
}