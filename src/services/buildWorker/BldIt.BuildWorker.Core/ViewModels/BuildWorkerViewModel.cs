namespace BldIt.BuildWorker.Core.ViewModels;

public class BuildWorkerViewModel
{
    public bool IsWorking { get; set; }
    public Guid? BuildId { get; set; }
    public int BuildNumber { get; set; }
    public Guid? JobId { get; set; }
}