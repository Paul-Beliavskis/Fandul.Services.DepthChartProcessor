using Fandul.Services.DepthChartProcessor.Application.Features.GetBackups;
using FluentValidation;

namespace Fandul.Services.DepthChartProcessor.Application.Features.GetAllPlayers
{
    public class GetAllPlayersQueryValidator : AbstractValidator<GetAllPlayersQuery>
    {
        public GetAllPlayersQueryValidator()
        {
            RuleFor(x => x.Sport).NotNull().WithMessage("You must provide a sport");
            RuleFor(x => x.TeamCode).NotNull().WithMessage("You must provide a team");
        }
    }
}
