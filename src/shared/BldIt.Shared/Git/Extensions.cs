using BldIt.Shared.Processes;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Shared.Git;

public static class Extensions
{
    /// <summary>
    /// Add GitManager to the service collection
    /// </summary>
    /// <param name="services">List of services</param>
    /// <param name="repositoryPath">Local path of where the repository is (null by default)</param>
    /// <param name="gitPath">Local git executable path (null by default)</param>
    /// <param name="throwIfProcessServiceNotRegistered">
    /// Should throw if IProcessService is not registered?
    /// (Otherwise, it'll add default implementation)
    /// </param>
    /// <returns>Service collection with GitManager added</returns>
    /// <exception cref="ArgumentNullException">If throwIfProcessServiceNotRegistered is true and IProcessService is not registered</exception>
    /// <remarks>
    /// If repositoryPath and gitPath are null, make sure you call Initialize(repoPath) before using the manager.
    /// </remarks>
    public static IServiceCollection AddGit(this IServiceCollection services, string? repositoryPath = null, string? gitPath = null,
        bool throwIfProcessServiceNotRegistered = true)
    {
        //Requires IProcessService to be registered
        var processService = services.BuildServiceProvider().GetRequiredService<IProcessService>();
        
        switch (processService)
        {
            case null when throwIfProcessServiceNotRegistered:
                throw new ArgumentNullException(nameof(processService));
            //Otherwise, register IProcessService with its default implementation
            case null:
                services.AddSingleton<IProcessService, ProcessService>();
                return services;
        }

        if (repositoryPath is not null && gitPath is not null)
        {
            services.AddSingleton<IGitManager>(new GitManager(processService, repositoryPath, gitPath));
            return services;
        }
        
        services.AddSingleton<IGitManager, GitManager>();
        return services;
    }
    
    
}