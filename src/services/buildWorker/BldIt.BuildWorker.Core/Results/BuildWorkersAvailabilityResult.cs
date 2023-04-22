using BldIt.BuildWorker.Core.ViewModels;

namespace BldIt.BuildWorker.Core.Results;

public class BuildWorkersAvailabilityResult
{
    public IEnumerable<BuildWorkerViewModel> BuildWorkers { get; set; }
}