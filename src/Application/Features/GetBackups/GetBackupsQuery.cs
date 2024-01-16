using Fandul.Services.DepthChartProcessor.Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fandul.Services.DepthChartProcessor.Application.Features.GetBackups
{
    public class GetBackupsQuery : IRequest<GetBackupsResponse>
    {
        public required SportsEnum Sport { get; set; }
        public required TeamsEnum Team { get; set; }
        public required string PlayerCode { get; set; }
        public required string Position { get; set; } = string.Empty;
        
    }
}