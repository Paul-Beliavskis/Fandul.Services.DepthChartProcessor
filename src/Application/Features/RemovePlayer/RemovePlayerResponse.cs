using Fandul.Services.DepthChartProcessor.Domain;

namespace Fandul.Services.DepthChartProcessor.Application.Features.RemovePlayer
{
    public class RemovePlayerQueryResponse
    {
        public List<Player> RemovedPlayers { get; set; } = new List<Player>();
    }
}
