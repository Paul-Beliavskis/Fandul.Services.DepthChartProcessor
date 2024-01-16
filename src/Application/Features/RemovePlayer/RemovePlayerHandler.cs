using Fandul.Services.DepthChartProcessor.Application.Exceptions;
using Fandul.Services.DepthChartProcessor.Application.Utils;
using Fandul.Services.DepthChartProcessor.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Fandul.Services.DepthChartProcessor.Application.Features.RemovePlayer
{
    public class RemovePlayerHandler : IRequestHandler<RemovePlayerQuery, RemovePlayerQueryResponse>
    {
        private readonly IMemoryCache _memoryCache;

        public RemovePlayerHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<RemovePlayerQueryResponse> Handle(RemovePlayerQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = CacheHelper.ConstructCacheKey(Enums.SportsEnum.NFL, "TB");

            var depthChart = _memoryCache.Get<Dictionary<string, LinkedList<Player>>>(cacheKey);

            var positionsLinkedList = depthChart?.GetValueOrDefault(request.Position);

            if (positionsLinkedList == null)
            {
                throw new BadRequestException($"{request.Position} position does not exist");
            }

            var response = new RemovePlayerQueryResponse();

            var playerToRemove = positionsLinkedList.FirstOrDefault(x => x.PlayerCode == request.PlayerCode);

            if (playerToRemove != null)
            {
                var isRemoved = positionsLinkedList.Remove(playerToRemove);

                if (isRemoved)
                {
                    _memoryCache.Set(cacheKey, depthChart);
                    response.RemovedPlayers.Add(playerToRemove);
                    return Task.FromResult(response);
                }
            }

            return Task.FromResult(response);
        }
    }
}