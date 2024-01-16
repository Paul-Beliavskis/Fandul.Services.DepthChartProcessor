using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Fandul.Services.DepthChartProcessor.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal("Host failed unexpectedly ", ex);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .CaptureStartupErrors(false); // This will ensure errors in the startup get propagated up instead of the default .NET Core behavior;
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("Api/appsettings.json", true, true)
                        .AddJsonFile($"Api/appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true)
                        .AddJsonFile("Api/appsettings.Local.json", true)
                        .AddEnvironmentVariables();
                })
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    loggerConfiguration
                        .ReadFrom.Configuration(hostingContext.Configuration)
                        .Enrich.FromLogContext();

                    AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
                });
    }
}
