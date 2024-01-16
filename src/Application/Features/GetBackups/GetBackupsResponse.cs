using Fandul.Services.DepthChartProcessor.Domain;

namespace Fandul.Services.DepthChartProcessor.Application.Features.GetBackups
{
    public class GetBackupsResponse
    {
        public List<Player> BackupPlayers { get; set; } = new List<Player>();
    }
}
