using Fandul.Services.DepthChartProcessor.Application.Common.Interfaces;
using Fandul.Services.DepthChartProcessor.Application.Enums;
using Fandul.Services.DepthChartProcessor.Application.Utils;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;

namespace Fandul.Services.DepthChartProcessor.Application.Common.BackgroundServices
{
    public class FetchDepthChartHostedService : IHostedService
    {
        private readonly IOurLadsClient _ourLadsClient;

        private readonly IMemoryCache _memoryCache;

        public FetchDepthChartHostedService(IOurLadsClient ourLadsClient, 
            IMemoryCache memoryCache)
        {
            _ourLadsClient = ourLadsClient;

            _memoryCache = memoryCache;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //For now we just hard code the team and sport but later we can pull from the db and fetch all the data for each team and sport
            var depthChart = await _ourLadsClient.GetDepthChartAsync(Enums.SportsEnum.NFL, TeamsEnum.TB);

            var cacheKey = CacheHelper.ConstructCacheKey(Enums.SportsEnum.NFL, "TB");

            _memoryCache.Set(cacheKey, depthChart);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
