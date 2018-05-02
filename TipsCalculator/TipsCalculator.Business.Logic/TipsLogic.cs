using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipsCalculator.Common.Logic.Models;
using TipsCalculator.DataAccess.Logic;

namespace TipsCalculator.Business.Logic
{
    public class TipsLogic : ITipsLogic
    {
        public List<Conversion> conversions = new List<Conversion>();
        public List<Order> orders = new List<Order>();
        private readonly IDaoLogic daoLogic;

        public TipsLogic(IDaoLogic daoLogic)
        {
            this.daoLogic = daoLogic;
        }

        public async Task<List<Conversion>> GetConversions()
        {
            var result = await this.daoLogic.GetConversions();
            return result;
        }

        public async Task<List<Order>> GetOrders()
        {
            var result = await this.daoLogic.GetOrders();
            return result;
        }

        public async Task<List<OrderWithTip>> GetOrdersTips(int tipPercentage)
        {
            var orders = await this.daoLogic.GetOrders();
            var ordersWithTip = orders
                .Select(x => new OrderWithTip() { Sku=x.Sku, Amount=x.Amount,
                                                Tip=calcularTip(tipPercentage, x.Amount), Currency=x.Currency })
                .ToList();
            return ordersWithTip;
        }

        private string calcularTip(int tipPercentage, string amount)
        {
            var money = Convert.ToDecimal(amount.Replace(".", ","));
            money = (money * tipPercentage / 100);
            money = Math.Round((money * 100), MidpointRounding.AwayFromZero) / 100;
            return Convert.ToString(money);
        }

        public async Task<List<Conversion>> GetAllConversions()
        {
            throw new NotImplementedException();
        }
    }
}