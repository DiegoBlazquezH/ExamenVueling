using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using TipsCalculator.Common.Logic.Configuration;

namespace TipsCalculator.DataAccess.WSVueling
{
    public class WSVuelingConfiguration
    {
        public static HttpClient InitClient(HttpClient client)
        {
            client.BaseAddress = new Uri(ConfigurationTools.GetWSVuelingConfiguration());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
