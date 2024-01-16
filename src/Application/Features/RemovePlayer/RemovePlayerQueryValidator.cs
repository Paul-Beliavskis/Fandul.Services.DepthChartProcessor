using FluentValidation;

namespace Fandul.Services.DepthChartProcessor.Application.Features.RemovePlayer
{
    public class RemovePlayerQueryQueryValidator : AbstractValidator<RemovePlayerQuery>
    {
        public RemovePlayerQueryQueryValidator()
        {
            RuleFor(x => x.Sport).NotNull().WithMessage("You must provide a sport");
            RuleFor(x => x.Position).NotEmpty().WithMessage("You must provide a position");
            RuleFor(x => x.PlayerCode).NotEmpty().WithMessage("You must provide a player code to delete");
            RuleFor(x => x.Team).NotNull().WithMessage("You must provide a team");
        }
    }
}
