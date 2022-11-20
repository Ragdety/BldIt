namespace BldIt.Projects.Contracts.Contracts;

/// <summary>
/// Used by other microservices to know when a project is updated
/// </summary>
/// <param name="Id">Id of the project that was updated</param>
/// <param name="ProjectWorkspacePath">Workspace path of the project that was updated</param>
public record ProjectUpdated(Guid Id, string ProjectWorkspacePath);