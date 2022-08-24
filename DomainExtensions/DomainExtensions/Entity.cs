namespace DomainExtensions;

public abstract class Entity<TId> where TId : BaseId
{
    public TId Id { get; protected set; }

    protected Entity()
    {
    }

    protected Entity(TId id)
    {
        Ensure.NotEmpty(id, "The identifier is required.", nameof(id));
        Id = id;
    }

    private bool IsTransient()
    {
        return Equals(default);
    }

    public override bool Equals(object obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (IsTransient() || other.IsTransient())
            return false;

        return Equals(other);
    }

    public static bool operator ==(Entity<TId> a, Entity<TId> b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TId> a, Entity<TId> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return GetType().GetHashCode();
    }
}