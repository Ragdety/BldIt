using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Core.Models;

namespace BldIt.Builds.Core.Repos;

public interface IBuildsRepo : IRepository<Build, Guid>
{
    Task<Build> GetLatestAsync();
    Task SetLatestAsync(Guid id);
}