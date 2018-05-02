using StackExchange.Redis;
using System;
using TipsCalculator.Common.Logic.Configuration;

namespace TipsCalculator.DataAccess.Redis
{
    public class RedisConfiguration
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisConfiguration()
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { ConfigurationTools.GetRedisConfiguration() }
            };

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();
    }
}
