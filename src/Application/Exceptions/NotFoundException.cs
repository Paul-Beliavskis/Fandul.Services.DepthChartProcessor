using System.Net;

namespace Fandul.Services.DepthChartProcessor.Application.Exceptions
{
    public  class NotFoundException : FandulExceptionBase
    {
        public NotFoundException(string description) : base(description, HttpStatusCode.NotFound)
        {
        }
    }
}
