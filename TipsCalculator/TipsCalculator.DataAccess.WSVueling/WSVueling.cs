using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using TipsCalculator.Common.Logic.Logger;
using TipsCalculator.Common.Logic.Resources;

namespace TipsCalculator.DataAccess.WSVueling
{
    public class WSVueling<T> : IWSVueling<T>
    {
        private readonly HttpClient Client = new HttpClient();
        private readonly ILogger logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);

        public WSVueling()
        {
            this.Client = WSVuelingConfiguration.InitClient(this.Client);
        }

        public async Task<T> GetAsync(string apiPath)
        {
            try
            {
                logger.Debug(MethodBase.GetCurrentMethod().DeclaringType.Name + ResourcesLogger.Start);
                var response = await Client.GetAsync(apiPath);
                response.EnsureSuccessStatusCode();
                using (HttpContent Content = response.Content)
                {
                    logger.Debug(MethodBase.GetCurrentMethod().DeclaringType.Name + ResourcesLogger.End);
                    var result = await Content.ReadAsAsync<T>();
                    return result;
                }
            }
            catch (Exception ex)
            {
                logger.Exception(ex);
                throw;
            }
        }
    }
}
