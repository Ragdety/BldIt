namespace BldIt.Api.Shared.Interfaces;

public interface IBldItQueue<T>
{
    void Queue(T task);
    Task<T> DequeueAsync(CancellationToken cancellationToken);
}