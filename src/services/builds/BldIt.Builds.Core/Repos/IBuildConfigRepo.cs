using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Core.Models;

namespace BldIt.Builds.Core.Repos;

public interface IBuildConfigRepo : IRepository<BuildConfig, Guid>
{
    Task<BuildConfig> GetBuildConfigForJobAsync(Guid jobId);
}