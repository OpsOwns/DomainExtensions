namespace DomainExtensions;

public interface IDomainEvent
{
    public int Version { get; protected set; }
    public DateTime OccuredOn { get; protected set; }
}