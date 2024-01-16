using FluentValidation;

namespace Fandul.Services.DepthChartProcessor.Application.Features.AddPlayer
{
    public class AddPlayerQueryValidator : AbstractValidator<AddPlayerQuery>
    {
        public AddPlayerQueryValidator()
        {
            RuleFor(x => x.Sport).NotNull().WithMessage("You must provide a sport");
            RuleFor(x => x.Position).NotNull().WithMessage("You must provide a position");
            RuleFor(x => x.Number).GreaterThan(-1).WithMessage("You must provide a player number");
            RuleFor(x => x.Team).NotNull().WithMessage("You must provide a team");
        }
    }
}
