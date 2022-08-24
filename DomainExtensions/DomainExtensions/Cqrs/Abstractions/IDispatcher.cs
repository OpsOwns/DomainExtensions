﻿namespace DomainExtensions.Cqrs.Abstractions;

public interface IDispatcher
{
    ValueTask<Result> SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    ValueTask<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}