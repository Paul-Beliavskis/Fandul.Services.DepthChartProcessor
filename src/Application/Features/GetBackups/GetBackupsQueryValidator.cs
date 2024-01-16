using FluentValidation;

namespace Fandul.Services.DepthChartProcessor.Application.Features.GetBackups
{
    public class GetBackupsQueryValidator : AbstractValidator<GetBackupsQuery>
    {
        public GetBackupsQueryValidator()
        {
            RuleFor(x => x.Sport).NotNull().WithMessage("You must provide a sport");
            RuleFor(x => x.PlayerCode).NotEmpty().WithMessage("You must provide a player code");
            RuleFor(x => x.Position).NotNull().WithMessage("You must provide a position");
            RuleFor(x => x.Team).NotNull().WithMessage("You must provide a team");
        }
    }
}
