namespace BldIt.BuildWorker.Contracts.Contracts;

public record BuildLogFileUpdate(Guid BuildId, string LogFilePath);