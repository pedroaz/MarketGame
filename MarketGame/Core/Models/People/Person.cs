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
        public List<StockCertificate> StockCertificates { get; set; } = new List<StockCertificate>();

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
        }

        /// <summary>
        /// God Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="money"></param>
        public Person()
        {
            PersonType = PersonType.God;
            Id = PERSON_GLOBAL_COUNTER++;
            Name = "GOD";
        }

        public void AddStockCertificate(Stock stock, int amount)
        {
            if (StockCertificates.Any(x => x.Stock.Name.Equals(stock.Name))) {
                StockCertificates.Find(x => x.Stock.Name.Equals(stock.Name)).Amount += amount;
            }
            else {
                StockCertificates.Add(new StockCertificate(stock, amount));
            }
        }

        public void ClearEmptyCertificates()
        {
            var emptyCertificates = new List<string>();

            foreach (var certificate in StockCertificates) {
                if (certificate.Amount.Equals(0)) emptyCertificates.Add(certificate.Stock.Name);
            }

            foreach (var stockName in emptyCertificates) {
                StockCertificates.RemoveAll(x => x.Stock.Name.Equals(stockName));
            }
        }
    }
}
