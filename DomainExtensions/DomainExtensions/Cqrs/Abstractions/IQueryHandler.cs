namespace DomainExtensions.Cqrs.Abstractions;

public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
{
    ValueTask<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}