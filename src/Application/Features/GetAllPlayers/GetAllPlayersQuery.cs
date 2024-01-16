using Fandul.Services.DepthChartProcessor.Application.Enums;
using Fandul.Services.DepthChartProcessor.Application.Features.GetAllPlayers;
using MediatR;

namespace Fandul.Services.DepthChartProcessor.Application.Features.GetBackups
{
    public class GetAllPlayersQuery : IRequest<GetAllPlayersQueryResponse>
    {
        public required SportsEnum Sport { get; set; }
        public required TeamsEnum TeamCode { get; set; }        
    }
}