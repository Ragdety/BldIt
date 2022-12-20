﻿using BldIt.Api.Shared.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.Api.Shared.Config;

public static class Extensions
{
    public static IServiceCollection AddBldItWorkspacePathConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var settingsSection = configuration.GetSection(nameof(BldItWorkspacePathSettings));

        if (settingsSection is null)
        {
            throw new ArgumentNullException(nameof(ServiceSettings));
        }
        
        services.Configure<BldItWorkspacePathSettings>(settingsSection);
        services.AddSingleton<BldItWorkspacePathConfig>();
        return services;
    }
}