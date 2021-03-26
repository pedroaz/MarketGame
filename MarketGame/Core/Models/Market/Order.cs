using MarketGame.Core.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.Market
{
    public class Order
    {
        public static int ORDER_GLOBAL_COUNTER = 0;
        public int Id { get; set; }
        public OrderType OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Stock Stock { get; set; }
        public int Amount { get; set; }
        public int AmountRemaining { get; set; }
        public decimal Value { get; set; }
        public Person Person { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreationTimeFormatted => CreationTime.ToString("yyyy/MM/dd - H:mm:ss");

        public Order(OrderType orderType, Stock stock, int amount, decimal value, Person person)
        {
            Id = ORDER_GLOBAL_COUNTER++;
            OrderStatus = OrderStatus.Open;
            CreationTime = DateTime.Now;

            OrderType = orderType;
            Stock = stock;
            Amount = amount;
            AmountRemaining = amount;
            Value = value;
            Person = person;
        }
    }
}
