using BldIt.Identity.Core.Interfaces;
using BldIt.Identity.Core.Repos;

namespace BldIt.Identity.Service;

public static class Extensions
{
    public static IServiceCollection AddIdentityRepositories(this IServiceCollection services)
    {
        services.AddScoped<IIdentityManager, IdentityManager>();
        
        return services;
    }
}