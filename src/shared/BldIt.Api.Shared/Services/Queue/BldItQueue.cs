using System.Collections.Concurrent;
using BldIt.Api.Shared.Interfaces;

namespace BldIt.Api.Shared.Services.Queue;

/// <summary>
/// Class to queue any item of type T
/// </summary>
/// <typeparam name="T">Type of items to be queued</typeparam>
public class BldItQueue<T> : IBldItQueue<T>
{
    protected readonly ConcurrentQueue<T> _items;
    protected readonly SemaphoreSlim _signal;

    /// <summary>
    /// Instantiate a BldItQueue with a maximum number of concurrent items
    /// </summary>
    /// <param name="maxConcurrent">Max number of concurrent items</param>
    public BldItQueue(int maxConcurrent)
    {
        _items = new ConcurrentQueue<T>();
        _signal = new SemaphoreSlim(maxConcurrent);
    }
    
    /// <summary>
    /// Instantiate a BldItQueue with no maximum number of concurrent items
    /// </summary>
    public BldItQueue() : this(0) { }

    /// <summary>
    /// Add item to the queue. Releases semaphore to allow dequeue
    /// </summary>
    /// <param name="item">Item to be queued</param>
    public virtual void Queue(T item)
    {
        _items.Enqueue(item);
        _signal.Release();
    }

    /// <summary>
    /// Dequeue an item from the queue. Waits for semaphore to be released
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel dequeue</param>
    /// <returns>The item dequeued</returns>
    /// <exception cref="ArgumentNullException">If dequeued item is null</exception>
    public virtual async Task<T> DequeueAsync(CancellationToken cancellationToken)
    {
        await _signal.WaitAsync(cancellationToken);
        
        _items.TryDequeue(out var item);

        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        
        return item;
    }
}