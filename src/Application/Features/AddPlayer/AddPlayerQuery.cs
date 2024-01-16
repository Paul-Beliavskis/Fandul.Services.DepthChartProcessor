using Fandul.Services.DepthChartProcessor.Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Fandul.Services.DepthChartProcessor.Application.Features.AddPlayer
{
    public class AddPlayerQuery : IRequest<AddPlayerResponse>
    {
        [JsonIgnore]
        public SportsEnum? Sport { get; set; }
        [JsonIgnore]
        public TeamsEnum? Team { get; set; }
        public string? Position { get; set; }
        public int? PositionDepth { get; set; }
        public int Number { get; set; } = -1;
        public required string Name { get; set; }
    }
}