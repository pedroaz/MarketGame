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
        public List<BotPerson> Bots { get; set; } = new List<BotPerson>();
        public List<HumanPerson> Humans { get; set; } = new List<HumanPerson>();
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Stock> Stocks { get; set; } = new List<Stock>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
