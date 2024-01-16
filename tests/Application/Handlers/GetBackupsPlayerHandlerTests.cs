
using FakeItEasy;
using Fandul.Services.DepthChartProcessor.Application.Exceptions;
using Fandul.Services.DepthChartProcessor.Application.Features.GetBackups;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fandul.Services.DepthChartProcessor.Unit.Tests.Handlers
{
    public class GetBackupsPlayerHandlerTests
    {
        private GetBackupsPlayerHandler _systemUnderTest;

        public GetBackupsPlayerHandlerTests()
        {

        }

        [Fact]
        public async Task Handle_PositionDoesNotExist_ExceptionIsThrown()
        {
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            _systemUnderTest = new GetBackupsPlayerHandler(memoryCache);
            var request = new GetBackupsQuery()
            {
                PlayerCode = "PaulBeliavskis",
                Position = "Position That Doesn't Exist",
                Sport = Application.Enums.SportsEnum.NFL,
                Team = Application.Enums.TeamsEnum.TB

            };

            await Assert.ThrowsAsync<NotFoundException>(async () => await _systemUnderTest.Handle(request, CancellationToken.None));
        }
    }
}
