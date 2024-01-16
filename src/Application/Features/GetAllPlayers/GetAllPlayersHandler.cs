using Fandul.Services.DepthChartProcessor.Application.Exceptions;
using Fandul.Services.DepthChartProcessor.Application.Features.GetAllPlayers;
using Fandul.Services.DepthChartProcessor.Application.Utils;
using Fandul.Services.DepthChartProcessor.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace Fandul.Services.DepthChartProcessor.Application.Features.GetBackups
{
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, GetAllPlayersQueryResponse>
    {
        private readonly IMemoryCache _memoryCache;

        public GetAllPlayersHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<GetAllPlayersQueryResponse> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = CacheHelper.ConstructCacheKey(Enums.SportsEnum.NFL, "TB");

            var depthChart = _memoryCache.Get<Dictionary<string, LinkedList<Player>>>(cacheKey);
            var response = new GetAllPlayersQueryResponse() { DepthChart = depthChart };

            return Task.FromResult(response);
        }
    }
}