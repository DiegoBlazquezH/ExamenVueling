using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Reflection;
using System.Threading.Tasks;
using TipsCalculator.Common.Logic.Logger;
using TipsCalculator.Common.Logic.Resources;

namespace TipsCalculator.DataAccess.Redis
{
    public class RedisDaoAsync<T> : IGetAsync<T>, ISetAsync<T>
    {
        private readonly IDatabase Redis;
        private readonly ILogger logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);

        public RedisDaoAsync()
        {
            this.Redis = RedisConfiguration.RedisCache;
        }

        public async Task<T> AddAsync(T entity, string key)
        {
            try
            {
                logger.Debug(MethodBase.GetCurrentMethod().DeclaringType.Name + ResourcesLogger.Start);
                await this.Redis.StringSetAsync(key, JsonConvert.SerializeObject(entity));
                logger.Debug(MethodBase.GetCurrentMethod().DeclaringType.Name + ResourcesLogger.Start);
                return await this.GetAsync(key);
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw;
            }
        }

        public async Task<T> GetAsync(string key)
        {
            try
            {
                logger.Debug(MethodBase.GetCurrentMethod().DeclaringType.Name + ResourcesLogger.Start);
                var result = JsonConvert.DeserializeObject<T>(await this.Redis.StringGetAsync(key));
                logger.Debug(MethodBase.GetCurrentMethod().DeclaringType.Name + ResourcesLogger.End);
                return result;
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw;
            }
        }
    }
}
