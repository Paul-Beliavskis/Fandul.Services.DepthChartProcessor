using Fandul.Services.DepthChartProcessor.Application.Common.Interfaces;
using Fandul.Services.DepthChartProcessor.Application.Enums;
using Fandul.Services.DepthChartProcessor.Domain;
using Fandul.Services.DepthChartProcessor.Infrastructure.Utils;

namespace Fandul.Services.DepthChartProcessor.Infrastructure.HttpCLients
{
    public class OurLadsClient : IOurLadsClient
    {
        private readonly HttpClient _httpClient;
        private readonly IDepthChartHtmlParser _depthChartHtmlParser;

        public OurLadsClient(HttpClient httpClient, 
            IDepthChartHtmlParser depthChartHtmlParser)
        {
            _httpClient = httpClient;
            _depthChartHtmlParser = depthChartHtmlParser;
        }

        public async Task<Dictionary<string, LinkedList<Player>>> GetDepthChartAsync(SportsEnum sport, TeamsEnum team)
        {
            var uri = $"/{sport}depthcharts/depthchart/{team}".ToLower();

            var responseString = await _httpClient.GetStringAsync(uri);
            var depthChart = _depthChartHtmlParser.ParseHtml(responseString);

            return depthChart;
        }
    }
}
