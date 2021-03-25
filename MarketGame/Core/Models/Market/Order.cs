using MarketGame.Core.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.Market
{
    public class Order
    {
        public static int OrderCounter = 0;
        public int Id {get; set; } =  OrderCounter++;
        public OrderType OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Stock Stock { get; set; }
        public int Amount { get; set; }
        public float Value { get; set; }
        public Person Person { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
