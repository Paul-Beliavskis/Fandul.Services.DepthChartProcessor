using Fandul.Services.DepthChartProcessor.Application.Exceptions;
using Fandul.Services.DepthChartProcessor.Application.Utils;
using Fandul.Services.DepthChartProcessor.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fandul.Services.DepthChartProcessor.Application.Features.AddPlayer
{
    public class AddPlayerHandler : IRequestHandler<AddPlayerQuery, AddPlayerResponse>
    {
        private readonly IMemoryCache _memoryCache;

        public AddPlayerHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<AddPlayerResponse> Handle(AddPlayerQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = CacheHelper.ConstructCacheKey(Enums.SportsEnum.NFL, "TB");

            var depthChart = _memoryCache.Get<Dictionary<string, LinkedList<Player>>>(cacheKey);

            var positionsLinkedList = depthChart?.GetValueOrDefault(request.Position);

            if (positionsLinkedList == null)
            {
                throw new BadRequestException($"{request.Position} position does not exist");
            }
            var existingPlayer = positionsLinkedList.FirstOrDefault(x => x.Number == request.Number);

            if (existingPlayer != null)
            {
                throw new ConflictException("A player with that number already exists in that position");
            }

            LinkedListNode<Player>? currentPlayerNode = null;

            if (request.PositionDepth != null)
            {
                var currentPlayer = positionsLinkedList.ElementAtOrDefault((int)request.PositionDepth);
                if (currentPlayer != null)
                {
                    currentPlayerNode = positionsLinkedList.Find(currentPlayer);
                }
            }

            var newPlayer = new Player()
            {
                Name = request.Name,
                Number = request.Number,
                Position = request?.Position?.ToString(),
                PlayerCode = Regex.Replace(request.Name, @"\s+", "")
        };

            if (currentPlayerNode != null)
            {
                positionsLinkedList.AddBefore(currentPlayerNode, newPlayer);
            }
            else
            {
                positionsLinkedList.AddLast(newPlayer);
            }

            _memoryCache.Set(cacheKey, depthChart);

            return Task.FromResult(new AddPlayerResponse() { AddedPlayer = newPlayer });
        }
    }
}