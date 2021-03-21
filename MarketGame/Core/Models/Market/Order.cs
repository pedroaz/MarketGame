using MarketGame.Core.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.Market
{
    public class Order
    {
        public OrderType OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Stock Stock { get; set; }
        public int Amount { get; set; }
        public float Value { get; set; }
        public Person Person { get; set; }
    }
}
