using Fandul.Services.DepthChartProcessor.Application.Enums;

namespace Fandul.Services.DepthChartProcessor.Application.Utils
{
    public static class CacheHelper
    {
        //This is incase we intend to share a distributed cache with out applications
        public const string ApplicationCacheKey = "DepthChartProcessor";

        public static string ConstructCacheKey(SportsEnum sport, string team)
        {
            return $"DepthChartProcessor:{sport}:{team}";
        }
    }
}
