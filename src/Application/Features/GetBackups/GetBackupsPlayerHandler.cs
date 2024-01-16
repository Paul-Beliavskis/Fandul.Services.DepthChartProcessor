using Fandul.Services.DepthChartProcessor.Application.Exceptions;
using Fandul.Services.DepthChartProcessor.Application.Utils;
using Fandul.Services.DepthChartProcessor.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace Fandul.Services.DepthChartProcessor.Application.Features.GetBackups
{
    public class GetBackupsPlayerHandler : IRequestHandler<GetBackupsQuery, GetBackupsResponse>
    {
        private readonly IMemoryCache _memoryCache;

        public GetBackupsPlayerHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<GetBackupsResponse> Handle(GetBackupsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = CacheHelper.ConstructCacheKey(Enums.SportsEnum.NFL, "TB");

            var depthChart = _memoryCache.Get<Dictionary<string, LinkedList<Player>>>(cacheKey);

            var positionsLinkedList = depthChart?.GetValueOrDefault(request.Position);

            if (positionsLinkedList == null)
            {
                throw new NotFoundException($"{request.Position} position does not exist");
            }

            var response = new GetBackupsResponse();

            var player = positionsLinkedList.FirstOrDefault(x => x.PlayerCode == request.PlayerCode);

            if (player != null)
            {
                var playerNode = positionsLinkedList.Find(player);
                playerNode = playerNode?.Next;

                while (playerNode != null)
                {
                    response.BackupPlayers.Add(playerNode.Value);
                    playerNode = playerNode.Next;
                }
            }
            else
            {
                throw new NotFoundException("Player was not found");
             }

            return Task.FromResult(response);
        }
    }
}