using System.Security.Claims;
using MassTransit;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Api.Shared.GitHub;

public static class Extensions
{
    public static IServiceCollection AddGitHubAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(o =>
            {
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddGitHub(BldItApiConstants.AuthenticationSchemes.GitHub, o =>
            {
                //AddGitHub already has all properties we need so far...
                o.ClientId = configuration["github:clientId"];
                o.ClientSecret = configuration["github:clientSecret"];
                o.Scope.Add("read:user");
                o.SaveTokens = true;

                o.Events.OnCreatingTicket = ctx =>
                {
                    if (ctx.AccessToken is { })
                    {
                        //Add the access token to the claims
                        ctx.Identity?.AddClaim(new Claim("github:access_token", ctx.AccessToken));
                    }
                    
                    return Task.CompletedTask;
                };

            });

        return services;
    }
}