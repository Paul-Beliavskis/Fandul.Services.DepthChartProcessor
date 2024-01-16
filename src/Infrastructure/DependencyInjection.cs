using Fandul.Services.DepthChartProcessor.Application.Common.Interfaces;
using Fandul.Services.DepthChartProcessor.Infrastructure.HttpCLients;
using Fandul.Services.DepthChartProcessor.Infrastructure.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Fandul.Services.DepthChartProcessor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient<IOurLadsClient, OurLadsClient>(client =>
            {
                client.BaseAddress = new Uri("https://www.ourlads.com");
            }

            );
            services.AddSingleton<IDepthChartHtmlParser, DepthChartHtmlParser>();
            return services;
        }
    }
}


