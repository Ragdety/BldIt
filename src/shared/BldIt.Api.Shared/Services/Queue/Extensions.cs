using BldIt.Api.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Api.Shared.Services.Queue;

public static class Extensions
{
    /// <summary>
    /// Adds singleton of BldItQueue
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <typeparam name="T">Type of item to be queued</typeparam>
    /// <returns>Service collection with added queue service</returns>
    public static IServiceCollection AddBldItQueue<T>(this IServiceCollection services)
    {
        services.AddSingleton<IBldItQueue<T>, BldItQueue<T>>();
        return services;
    }
}