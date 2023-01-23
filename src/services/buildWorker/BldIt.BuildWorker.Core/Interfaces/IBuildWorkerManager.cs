namespace BldIt.BuildWorker.Core.Interfaces;

public interface IBuildWorkerManager
{
    IBuildWorker AddActiveWorker(Guid buildId);
    void RemoveActiveWorker(Guid buildId);
}