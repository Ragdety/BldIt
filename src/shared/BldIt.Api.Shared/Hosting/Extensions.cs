using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BldIt.Api.Shared.Hosting;

public static class Extensions
{
    public const string DockerEnvironment = "Docker";
 
    public static bool IsDocker(this IWebHostEnvironment hostingEnvironment)
    {
        return hostingEnvironment.IsEnvironment(DockerEnvironment);
    }
}