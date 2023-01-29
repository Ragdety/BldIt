namespace BldIt.BuildWorker.Core.Interfaces;

public interface IBuildWorkerHubConnectionManager
{
    void AddConnection(Guid buildId, string? connectionId);
    void RemoveConnection(Guid buildId);
    string? GetConnection(Guid buildId);
    bool HasConnections();
}