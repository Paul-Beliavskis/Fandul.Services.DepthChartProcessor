using System.Threading.Tasks;
using Fandul.Services.DepthChartProcessor.Application.Features.AddPlayer;
using Fandul.Services.DepthChartProcessor.Application.Features.RemovePlayer;
using FluentValidation;
using Xunit;

namespace Fandul.Services.DepthChartProcessor.Unit.Tests.Validators.Request
{
    public class DemoValidatorTests
    {
        private readonly IValidator _validator;

        public DemoValidatorTests()
        {
            _validator = new AddPlayerQueryValidator();
        }

        [Fact]
        public async Task ValidateAsync_IsRequestValid_RequestIsNotValid()
        {
            var request = new AddPlayerQuery { Name = "" };
            var context = new ValidationContext<AddPlayerQuery>(request);

            var result = await _validator.ValidateAsync(context);

            Assert.NotNull(result.Errors);
        }
    }
}
