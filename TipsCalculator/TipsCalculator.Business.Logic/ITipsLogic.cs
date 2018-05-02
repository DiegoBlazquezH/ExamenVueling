using System.Collections.Generic;
using System.Threading.Tasks;
using TipsCalculator.Common.Logic.Models;

namespace TipsCalculator.Business.Logic
{
    public interface ITipsLogic
    {
        Task<List<Conversion>> GetConversions();
        Task<List<Order>> GetOrders();
        Task<List<OrderWithTip>> GetOrdersTips(int tipPercentage);
    }
}
