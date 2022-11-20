namespace BldIt.Projects.Contracts.Contracts;

/// <summary>
/// Used by other microservices to know when a project is deleted
/// </summary>
/// <param name="Id">Id of the project</param>
public record ProjectDeleted(Guid Id);