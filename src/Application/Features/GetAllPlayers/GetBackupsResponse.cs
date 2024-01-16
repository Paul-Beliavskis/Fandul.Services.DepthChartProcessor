using Fandul.Services.DepthChartProcessor.Domain;

namespace Fandul.Services.DepthChartProcessor.Application.Features.GetAllPlayers
{
    public class GetAllPlayersQueryResponse
    {
        public Dictionary<string, LinkedList<Player>> DepthChart { get; set; } = [];
    }
}
