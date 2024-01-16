using System.Net;

namespace Fandul.Services.DepthChartProcessor.Application.Exceptions
{
    public class ConflictException : FandulExceptionBase
    {
        public ConflictException(string description) : base(description, HttpStatusCode.Conflict)
        {

        }
    }
}
