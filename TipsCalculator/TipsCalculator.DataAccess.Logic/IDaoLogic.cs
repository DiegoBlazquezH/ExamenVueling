using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Common.Logic.Models;
using TipsCalculator.DataAccess.Redis;
using TipsCalculator.DataAccess.WSVueling;

namespace TipsCalculator.DataAccess.Logic
{
    public interface IDaoLogic
    {
        Task<List<Conversion>> GetConversions();
        Task<List<Order>> GetOrders();
        Task<List<Conversion>> GetConversionsWs();
        Task<List<Order>> GetOrdersWs();
        Task<List<Conversion>> GetConversionsRedis();
        Task<List<Order>> GetOrdersRedis();
        Task<List<Conversion>> SetConversionsRedis(List<Conversion> conversions);
        Task<List<Order>> SetOrdersRedis(List<Order> orders);
    }
}
