namespace DomainExtensions;

public record BaseId
{
    public Guid Value { get; }

    protected BaseId()
    {
        Value = Guid.NewGuid();
    }

    protected BaseId(Guid value)
    {
        Value = value;
    }

    public override string ToString() => Value.ToString();

    public static implicit operator BaseId(Guid identity) => new(identity);

    public static implicit operator Guid(BaseId identity) => identity.Value;
}