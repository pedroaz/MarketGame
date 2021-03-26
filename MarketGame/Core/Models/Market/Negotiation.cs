using MarketGame.Core.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.Market
{
    public class Negotiation
    {

        public static int NEGOTIATION_GLOBAL_COUNTER = 0;
        
        
        public int Id { get; set; }
        public Stock Stock { get; set; }
        public Person Buyer { get; set; }
        public Person Seller { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
        public DateTime Time { get; set; }
        public string TimeFormatted => Time.ToString("yyyy/MM/dd - H:mm:ss");

        public Negotiation(Stock stock, Person buyer, Person seller, int amount, decimal value)
        {
            Id = NEGOTIATION_GLOBAL_COUNTER++;

            Stock = stock;
            Buyer = buyer;
            Seller = seller;
            Amount = amount;
            Value = value;
            Time = DateTime.Now;
        }
    }
}
