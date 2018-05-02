using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TipsCalculator.Common.Logic.Models
{
    public class Conversion : IModel
    {
        
        public Guid ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Rate { get; set; }

        public Conversion(string fromCurrency, string toCurrency, string rate)
        {
            this.ID = Guid.NewGuid();
            this.From = fromCurrency;
            this.To = toCurrency;
            this.Rate = rate;
        }
    }
}
