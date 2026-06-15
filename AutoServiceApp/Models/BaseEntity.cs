namespace AutoServiceApp.Models;

public abstract class BaseEntity
{
    public string Id { get; private set; } = Guid.NewGuid().ToString("N");

    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    public bool IsDeleted { get; private set; }

    public void MarkDeleted()
    {
        IsDeleted = true;
    }

    public void Restore()
    {
        IsDeleted = false;
    }
}