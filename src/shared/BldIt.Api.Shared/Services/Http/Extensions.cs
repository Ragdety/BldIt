using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Api.Shared.Services.Http;

public static class Extensions
{
    public static IServiceCollection AddHttpService(this IServiceCollection services, string baseUrl)
    {
        services.AddHttpClient<IHttpService, HttpService>(client =>
        {
            client.BaseAddress = new System.Uri(baseUrl);
        });
        return services;
    }
    
    public static IServiceCollection AddHttpService(this IServiceCollection services, Action<HttpClient> configureClient)
    {
        services.AddHttpClient<IHttpService, HttpService>(configureClient);
        return services;
    }

    public static IServiceCollection AddHttpService<T>(this IServiceCollection services, string baseUrl)
        where T : class, IHttpService
    {
        services.AddHttpClient<IHttpService, T>(client =>
        {
            client.BaseAddress = new System.Uri(baseUrl);
        });
        return services;
    }
    
    public static IServiceCollection AddHttpService<T>(this IServiceCollection services, Action<HttpClient> configureClient)
        where T : class, IHttpService
    {
        services.AddHttpClient<IHttpService, T>(configureClient);
        return services;
    }
}