using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using TipsCalculator.Common.Logic.Logger;
using TipsCalculator.Common.Logic.Models;
using TipsCalculator.Common.Logic.Resources;
using TipsCalculator.DataAccess.Redis;
using TipsCalculator.DataAccess.Redis.Resources;
using TipsCalculator.DataAccess.WSVueling;
using TipsCalculator.DataAccess.WSVueling.Resources;

namespace TipsCalculator.DataAccess.Logic
{
    public class DaoLogic : IDaoLogic
    {
        private readonly IGetAsync<List<Conversion>> GetConversion;
        private readonly ISetAsync<List<Conversion>> SetConversion;
        private readonly IWSVueling<List<Conversion>> WsVuelingConversion;
        private readonly IGetAsync<List<Order>> GetOrder;
        private readonly ISetAsync<List<Order>> SetOrder;
        private readonly IWSVueling<List<Order>> WsVuelingOrder;

        private readonly ILogger logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);

        public DaoLogic(IGetAsync<List<Conversion>> getConversion, ISetAsync<List<Conversion>> setConversion,
            IWSVueling<List<Conversion>> wsVuelingConversion,
            IGetAsync<List<Order>> getOrder, ISetAsync<List<Order>> setOrder,
            IWSVueling<List<Order>> wsVuelingOrder)
        {
            GetConversion = getConversion;
            SetConversion = setConversion;
            WsVuelingConversion = wsVuelingConversion;
            GetOrder = getOrder;
            SetOrder = setOrder;
            WsVuelingOrder = wsVuelingOrder;
        }
        
        public async Task<List<Conversion>> GetConversions()
        {
            var conversions = await GetConversionsWs();
            if (conversions.Count == 0)
                conversions = await GetConversionsRedis();
            else
                conversions = await SetConversionsRedis(conversions);
            return conversions;
        }

        public async Task<List<Order>> GetOrders()
        {
            try
            {
                logger.Debug(MethodBase.GetCurrentMethod().DeclaringType.Name + ResourcesLogger.Start);
                var orders = await GetOrdersWs();
                if (orders.Count == 0)
                    orders = await GetOrdersRedis();
                else
                    orders = await SetOrdersRedis(orders);
                logger.Debug(MethodBase.GetCurrentMethod().DeclaringType.Name + ResourcesLogger.End);
                return orders;
            }
            catch (System.Exception ex)
            {
                logger.Exception(ex);
                throw;
            }
        }

        public async Task<List<Conversion>> GetConversionsWs()
        {
            var conversions = await WsVuelingConversion.GetAsync(Api.Rates);
            return conversions;
        }

        public async Task<List<Order>> GetOrdersWs()
        {
            var orders = await WsVuelingOrder.GetAsync(Api.Transactions);
            return orders;
        }

        public async Task<List<Conversion>> GetConversionsRedis()
        {
            var conversions = await GetConversion.GetAsync(Keys.KeyConversions);
            return conversions;
        }

        public async Task<List<Order>> GetOrdersRedis()
        {
            var orders = await GetOrder.GetAsync(Keys.KeyOrders);
            return orders;
        }

        public async Task<List<Conversion>> SetConversionsRedis(List<Conversion> conversions)
        {
            conversions = await SetConversion.AddAsync(conversions, Keys.KeyConversions);
            return conversions;
        }

        public async Task<List<Order>> SetOrdersRedis(List<Order> orders)
        {
            orders = await SetOrder.AddAsync(orders, Keys.KeyOrders);
            return orders;
        }
    }
}
