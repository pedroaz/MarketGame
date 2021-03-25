using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.Market
{
    public class Stock
    {
        public string Name { get; set; }
        public decimal LastNegotiationPrice { get; set; }
    }
}
