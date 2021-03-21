using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.Market
{
    public class StockCertificate
    {
        public Stock Stock { get; set; }
        public int Amount { get; set; }
        public float ValueWhenBought { get; set; }
        public DateTime BoughtDate { get; set; }
    }
}
