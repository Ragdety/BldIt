using BldIt.BuildScheduler.Contracts.Contracts;

namespace BldIt.BuildWorker.Contracts.Contracts;

public record BuildWorkerCapacityReached(StartBuildRequest BuildRequest);