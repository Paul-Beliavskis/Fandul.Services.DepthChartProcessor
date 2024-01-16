using System.Net;

namespace Fandul.Services.DepthChartProcessor.Application.Exceptions
{
    public abstract class FandulExceptionBase : Exception
    {
        public string Description { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public FandulExceptionBase(string description, HttpStatusCode httpStatusCode)
        {
            Description = description;

            StatusCode = httpStatusCode;
        }
    }
}
