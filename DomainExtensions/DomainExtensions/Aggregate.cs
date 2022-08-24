namespace DomainExtensions;

public abstract class Aggregate<TId> : Entity<TId> where TId : BaseId
{
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    public bool HasEvents => _domainEvents.Any();
    public int Version { get; internal set; }

    public void LoadFromHistory(IEnumerable<IDomainEvent> events)
    {
        foreach (var @event in events)
        {
            ApplyEvent(@event);
        }
    }

    protected void AddEvent(IDomainEvent domainEvent)
    {
        Ensure.NotNull(domainEvent);
        _domainEvents.Add(domainEvent);
        Version++;
    }

    protected virtual void ApplyEvent(IDomainEvent domainEvent)
    {
        if (domainEvent is null)
            return;

        Version = domainEvent.Version + 1;
    }

    public void MarkChangesAsCommitted()
    {
        _domainEvents.Clear();
    }
}