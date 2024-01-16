using Fandul.Services.DepthChartProcessor.Application.Enums;
using MediatR;

namespace Fandul.Services.DepthChartProcessor.Application.Features.RemovePlayer
{
    public class RemovePlayerQuery : IRequest<RemovePlayerQueryResponse>
    {
        public required SportsEnum Sport { get; set; }
        public required TeamsEnum Team { get; set; }
        public required string PlayerCode { get; set; }
        public required string Position { get; set; } = string.Empty;
        
    }
}