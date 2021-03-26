using MarketGame.Core.Models.Companies;
using MarketGame.Core.Models.Market;
using MarketGame.Core.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.State
{
    public class GameState
    {
        public bool AutoSimulation { get; set; } = false;
        public int ManualSimulationCounter { get; set; } = 0;

        public List<Person> People { get; set; } = new List<Person>();
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Stock> Stocks { get; set; } = new List<Stock>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Negotiation> Negotiations { get; set; } = new List<Negotiation>();
        public Person God { get; set; }
    }
}
