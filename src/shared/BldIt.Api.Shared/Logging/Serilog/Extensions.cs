using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BldIt.Api.Shared.Logging.Serilog;

public static class Extensions
{
    /// <summary>
    /// Adds and configures Serilog to the logging pipeline
    /// </summary>
    /// <param name="logging">Logging builder</param>
    /// <param name="configuration">Configuration from the builder</param>
    /// <param name="clearProviders">Clear logging providers. True by default</param>
    /// <returns>Returns an ILoggingBuilder with the new Serilog configuration</returns>
    public static ILoggingBuilder ConfigureAndAddSerilog(
        this ILoggingBuilder logging, 
        IConfiguration configuration,
        bool clearProviders = true)
    {
        var loggerConfig = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console();

        var logger = loggerConfig.CreateLogger();
        
        if (clearProviders) logging.ClearProviders();
        logging.AddSerilog(logger);

        return logging;
    }

    /// <summary>
    /// Adds Serilog with a custom configuration
    /// </summary>
    /// <param name="logging">Logging builder</param>
    /// <param name="loggerConfiguration">Custom logger configuration</param>
    /// <param name="clearProviders">Clear logging providers. True by default</param>
    /// <returns>Returns an ILoggingBuilder with the new Serilog configuration</returns>
    public static ILoggingBuilder ConfigureAndAddSerilog(
        this ILoggingBuilder logging,
        LoggerConfiguration loggerConfiguration,
        bool clearProviders = true)
    {
        if (clearProviders) logging.ClearProviders();
        var logger = loggerConfiguration.CreateLogger();
        logging.AddSerilog(logger);
        return logging;
    }
}