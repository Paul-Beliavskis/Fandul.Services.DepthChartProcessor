using FakeItEasy;
using Fandul.Services.DepthChartProcessor.Application.Enums;
using Fandul.Services.DepthChartProcessor.Application.Features.RemovePlayer;
using Fandul.Services.DepthChartProcessor.Application.Utils;
using Fandul.Services.DepthChartProcessor.Domain;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fandul.Services.DepthChartProcessor.Unit.Tests.Handlers
{
    public class RemovePlayerHandlerTests
    {
        private RemovePlayerHandler _systemUnderTest;

        public RemovePlayerHandlerTests()
        {
        }

        [Fact]
        public async Task Handle_ValidPlayerToRemove_RemovedPlayerIsReturned()
        {
            //Arrange
            var request = new RemovePlayerQuery()
            {
                PlayerCode = "PaulBeliavskis",
                Sport = SportsEnum.NFL,
                Team = TeamsEnum.TB,
                Position = "LWR"
            };

            var linkedList = new LinkedList<Player>();
            linkedList.AddLast(new Player()
            {
                Name = "Paul Beliavskis",
                Number = 12,
                PlayerCode = "PaulBeliavskis",
                Position = "LWR"
            });
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var cacheKey = CacheHelper.ConstructCacheKey(Application.Enums.SportsEnum.NFL, "TB");

            memoryCache.Set<Dictionary<string, LinkedList<Player>>>(cacheKey, new Dictionary<string, LinkedList<Player>>()
                {
                    { "LWR", linkedList },
                });

            _systemUnderTest = new RemovePlayerHandler(memoryCache);

            //Act and Assert
            var response = await _systemUnderTest.Handle(request, CancellationToken.None);

            response.Should().NotBeNull();
            response.RemovedPlayers.Should().NotBeNullOrEmpty();
            response.RemovedPlayers.Should().HaveCount(1);
        }
    }
}
