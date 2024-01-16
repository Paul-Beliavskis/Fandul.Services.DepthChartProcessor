using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Fandul.Services.DepthChartProcessor.Application.Enums;
using Fandul.Services.DepthChartProcessor.Application.Features.AddPlayer;
using Fandul.Services.DepthChartProcessor.Application.Features.RemovePlayer;
using Fandul.Services.DepthChartProcessor.Application.Features.GetBackups;

namespace Fandul.Services.DepthChartProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepthChartsController : ControllerBase
    {
        private readonly ILogger _logger;

        private readonly IMediator _mediator;

        public DepthChartsController(ILogger logger, IMediator mediator)
        {
            _logger = logger;

            _mediator = mediator;
        }

        [HttpPut("sports/{sport}/teams/{team}/players")]
        public async Task<IActionResult> AddPlayer(SportsEnum sport, TeamsEnum team, AddPlayerQuery addPlayerQuery)
        {
            addPlayerQuery.Sport = sport;
            addPlayerQuery.Team = team;

            //IPipeline behaviours will error this out because of the fluent validation rules setup in DemoRequestValidator.cs
            //When the error occures it is picked up by the exception handling middleware and a bad request will be returned
            await _mediator.Send(addPlayerQuery);

            return Created();
        }

        [HttpDelete("sports/{sport}/teams/{team}/positions/{position}/players/{playerCode}")]
        public async Task<IActionResult> RemovePlayer(SportsEnum sport, TeamsEnum team, string position, string playerCode)
        {
            var removePlayerQuery = new RemovePlayerQuery()
            {
                PlayerCode = playerCode,
                Position = position?.ToUpper(),
                Sport = sport,
                Team = team
            };

            //IPipeline behaviours will error this out because of the fluent validation rules setup in DemoRequestValidator.cs
            //When the error occures it is picked up by the exception handling middleware and a bad request will be returned
            var response = await _mediator.Send(removePlayerQuery);

            return Ok(response);
        }
        [HttpGet("sports/{sport}/teams/{team}/positions/{position}/players/{playerCode}/backups")]
        public async Task<IActionResult> GetBackups(SportsEnum sport, TeamsEnum team, string position, string playerCode)
        {
            var getBackupsQuery = new GetBackupsQuery()
            {
                PlayerCode = playerCode,
                Position = position?.ToUpper(),
                Sport = sport,
                Team = team
            };

            //IPipeline behaviours will error this out because of the fluent validation rules setup in DemoRequestValidator.cs
            //When the error occures it is picked up by the exception handling middleware and a bad request will be returned
            var response = await _mediator.Send(getBackupsQuery);

            return Ok(response);
        }

        [HttpGet("sports/{sport}/teams/{team}")]
        public async Task<IActionResult> GetFullDepthChart(SportsEnum sport, TeamsEnum team)
        {
            var request = new GetAllPlayersQuery() { Sport = sport, TeamCode = team };

            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}

