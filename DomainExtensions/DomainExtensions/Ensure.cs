namespace DomainExtensions;

public static class Ensure
{
    public static void NotEmpty(string value, string message, string argumentName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotEmpty(BaseId value, string message, string argumentName)
    {
        if (value.Value == Guid.Empty)
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotNull<T>(T value)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(value);
    }
}