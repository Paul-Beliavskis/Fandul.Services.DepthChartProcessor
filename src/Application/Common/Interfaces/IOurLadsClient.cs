using Fandul.Services.DepthChartProcessor.Application.Enums;
using Fandul.Services.DepthChartProcessor.Domain;

namespace Fandul.Services.DepthChartProcessor.Application.Common.Interfaces
{
    public interface IOurLadsClient
    {
        Task<Dictionary<string, LinkedList<Player>>> GetDepthChartAsync(SportsEnum sport, TeamsEnum teamCode);
    }
}
