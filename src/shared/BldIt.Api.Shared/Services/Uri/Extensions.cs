using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Api.Shared.Services.Uri;

public static class Extensions
{
    public static IServiceCollection AddUriService(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        
        //UriService: Used to generate links to resources
        services.AddSingleton(provider =>
        {
            //Gets the absolute uri. Ex: https://localhost or https://bldit.com
            var accessor = provider.GetRequiredService<IHttpContextAccessor>();
            var request = accessor.HttpContext?.Request;
            var absoluteUri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent(), "/");
            //Pass absoluteUri to constructor of UriService"
            return new UriService(absoluteUri);
        });
        
        return services;
    }
}