namespace BldIt.Projects.Contracts.Contracts;

/// <summary>
/// Used by other microservices to know when a project is created
/// </summary>
/// <param name="Id">Id of the project</param>
/// <param name="ProjectWorkspacePath">Workspace path of the project</param>
public record ProjectCreated(Guid Id, string ProjectWorkspacePath);