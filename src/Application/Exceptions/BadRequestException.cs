
using System.Net;

namespace Fandul.Services.DepthChartProcessor.Application.Exceptions
{
    public class BadRequestException : FandulExceptionBase
    {
        public BadRequestException(string description) : base(description, HttpStatusCode.BadRequest)
        {
        }
    }
}
