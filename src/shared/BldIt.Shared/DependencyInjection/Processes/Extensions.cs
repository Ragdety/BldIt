using BldIt.Shared.Processes;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Shared.DependencyInjection.Processes;

public static class Extensions
{
    /// <summary>
    /// Adds a custom implementation of <see cref="IProcessService"/> to the service collection.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <typeparam name="TProcessService">Custom implementation of IProcessService</typeparam>
    /// <returns>The service collection the TProcessService added</returns>
    public static IServiceCollection AddProcessService<TProcessService>(
        this IServiceCollection services)
        where TProcessService : class, IProcessService
    {
        services.AddTransient<IProcessService, TProcessService>();
        return services;
    }
    
    /// <summary>
    /// Adds a custom implementation of <see cref="IProcessService"/>
    /// to the service collection with the provided implementation factory.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="implementationFactory">Implementation factory handler</param>
    /// <typeparam name="TProcessService">Custom implementation of IProcessService</typeparam>
    /// <returns>The service collection the TProcessService added</returns>
    public static IServiceCollection AddProcessService<TProcessService>(
        this IServiceCollection services, 
        Func<IServiceProvider, TProcessService> implementationFactory)
        where TProcessService : class, IProcessService
    {
        services.AddTransient<IProcessService, TProcessService>(implementationFactory);
        return services;
    }

    /// <summary>
    /// Adds the default implementation of <see cref="IProcessService"/> to the service collection.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <returns>The service collection with a new <see cref="ProcessService"/> added</returns>
    public static IServiceCollection AddDefaultProcessService(this IServiceCollection services)
    {
        services.AddTransient<IProcessService, ProcessService>();
        return services;
    }
}