using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsCalculator.Common.Logic.Models
{
    public class Order : IModel
    {
        public Guid ID { get; set; }
        public string Sku { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }

        public Order(string sku, string amount, string currency)
        {
            this.ID = Guid.NewGuid();
            this.Sku = sku;
            this.Amount = amount;
            this.Currency = currency;
        }
    }
}
