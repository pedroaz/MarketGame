using MarketGame.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.People
{
    public class Person
    {

        public static int PERSON_GLOBAL_COUNTER = 0;
        public int Id { get; set; }
        public PersonType PersonType { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public Dictionary<string, StockCertificate> StockCertificates { get; set; }


        /// <summary>
        /// Human Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="money"></param>
        public Person(string name, decimal money)
        {
            PersonType = PersonType.Human;
            Id = PERSON_GLOBAL_COUNTER++;

            Name = name;
            Money = money;
            StockCertificates = new Dictionary<string, StockCertificate>();
        }

        /// <summary>
        /// Bot constructor
        /// </summary>
        /// <param name="money"></param>
        public Person(decimal money)
        {
            PersonType = PersonType.Bot;
            Id = PERSON_GLOBAL_COUNTER++;

            Name = $"BOT_{Id}";
            Money = money;
            StockCertificates = new Dictionary<string, StockCertificate>();
        }

        public void AddStockCertificate(Stock stock, int amount)
        {
            if (StockCertificates.ContainsKey(stock.Name)) {
                StockCertificates[stock.Name].Amount += amount;
            }
            else {
                StockCertificates.Add(stock.Name, new StockCertificate(stock, amount));
            }
        }

        public void ClearEmptyCertificates()
        {
            var emptyCertificates = new List<string>();

            foreach (var certificate in StockCertificates) {
                if (certificate.Value.Amount.Equals(0)) emptyCertificates.Add(certificate.Value.Stock.Name);
            }

            foreach (var stockName in emptyCertificates) {
                StockCertificates.Remove(stockName);
            }
        }
    }
}
