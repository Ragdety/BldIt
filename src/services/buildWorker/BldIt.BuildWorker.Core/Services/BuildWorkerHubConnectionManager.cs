using System.Collections.Concurrent;
using BldIt.BuildWorker.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace BldIt.BuildWorker.Core.Services;

public class BuildWorkerHubConnectionManager : IBuildWorkerHubConnectionManager
{
    private ConcurrentDictionary<Guid, string?> Connections { get; }
    private readonly ILogger<BuildWorkerHubConnectionManager> _logger;
    
    public BuildWorkerHubConnectionManager(ILogger<BuildWorkerHubConnectionManager> logger)
    {
        _logger = logger;
        Connections = new ConcurrentDictionary<Guid, string?>();
    }
    
    public void AddConnection(Guid buildId, string? connectionId)
    {
        var addSuccess = Connections.TryAdd(buildId, connectionId);
        if (addSuccess)
        {
            _logger.LogInformation("Connection has been added successfully: {Connections}", Connections);
        }
        else
        {
            _logger.LogWarning("Connection has failed to be added: {Connections}", Connections);
        }
        _logger.LogInformation("Connections: {Connections}", Connections);
    }
    
    public void RemoveConnection(Guid buildId)
    {
        if (!HasConnections()) return;
        if (!HasKey(buildId)) return;
        
        Connections.TryRemove(buildId, out var connectionId);
        _logger.LogInformation("Connections: {Connections}", Connections);
    }

    public string? GetConnection(Guid buildId) => HasConnections() ? Connections[buildId] : null;

    public bool HasConnections() => Connections.Any();

    private bool HasKey(Guid buildId)
    {
        return Connections.ContainsKey(buildId);
    }
}