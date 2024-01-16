using System.Collections.Generic;

namespace Fandul.Services.DepthChartProcessor.Models
{
    public class ErrorModel
    {
        public string Description { get; set; }

        public IEnumerable<ValidationErrorModel> ValidationErrors { get; set; }
    }
}
