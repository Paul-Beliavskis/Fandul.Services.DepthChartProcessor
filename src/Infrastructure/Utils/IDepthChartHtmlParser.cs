

using Fandul.Services.DepthChartProcessor.Domain;

namespace Fandul.Services.DepthChartProcessor.Infrastructure.Utils
{
    public interface IDepthChartHtmlParser
    {
        Dictionary<string, LinkedList<Player>> ParseHtml(string html);
    }
}
