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
        public string Name { get; set; }
        public float Money { get; set; }
        /// <summary>
        /// string = name | int = amount
        /// </summary>
        public IDictionary<string, int> Stocks { get; set; }
    }
}
