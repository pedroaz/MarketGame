using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.Market
{
    public class Stock
    {
        public string Name { get; set; }
        public float LastNegotiationPrice { get; set; }
        public List<BuyStockOffer> BuyOffers { get; set; }
        public List<SellStockOffer> SellOffers { get; set; }
    }
}
