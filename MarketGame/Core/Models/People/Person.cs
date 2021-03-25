using MarketGame.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.Models.People
{
    public class Person
    {
        public int Id { get; set; }
        public PersonType PersonType { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<StockCertificate> StockCertificates { get; set; }

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
