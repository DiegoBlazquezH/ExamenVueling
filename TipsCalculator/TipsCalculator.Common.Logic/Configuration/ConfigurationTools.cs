using System.Configuration;

namespace TipsCalculator.Common.Logic.Configuration
{
    public static class ConfigurationTools
    {
        public static string GetRedisConfiguration()
        {
            return ConfigurationManager.AppSettings["RedisEndPoint"];
        }

        public static string GetWSVuelingConfiguration()
        {
            return ConfigurationManager.AppSettings["BaseApiWSVuelingUrl"];
        }
    }
}
