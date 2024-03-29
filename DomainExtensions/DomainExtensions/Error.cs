﻿namespace DomainExtensions;

public sealed class Error : ValueObject
{
    public string Code { get; }
    public string Message { get; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;

    internal static Error None => new Error(string.Empty, string.Empty);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Message;
    }
}