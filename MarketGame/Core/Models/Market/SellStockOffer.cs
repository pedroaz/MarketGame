using MarketGame.Core.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.Market
{
    public class SellStockOffer
    {
        public Person Seller { get; set; }
        public float Offer { get; set; }
        public int Amount { get; set; }
    }
}
