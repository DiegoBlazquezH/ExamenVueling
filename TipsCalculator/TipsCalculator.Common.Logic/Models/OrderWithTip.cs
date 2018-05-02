using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsCalculator.Common.Logic.Models
{
    public class OrderWithTip : IModel
    {
        public Guid ID { get; set; }
        public string Sku { get; set; }
        public string Amount { get; set; }
        public string Tip { get; set; }
        public string Currency { get; set; }

        public OrderWithTip()
        {
            this.ID = Guid.NewGuid();
        }

        public OrderWithTip(string sku, string amount, string tip, string currency)
        {
            this.ID = Guid.NewGuid();
            this.Sku = sku;
            this.Amount = amount;
            this.Tip = tip;
            this.Currency = currency;
        }
    }
}
