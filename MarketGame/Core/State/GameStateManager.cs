﻿using MarketGame.Core.Models.Companies;
using MarketGame.Core.Models.Market;
using MarketGame.Core.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.State
{
    public class GameStateManager : IGameStateManager
    {
        public List<BotPerson> Bots { get; set; }
        public List<Person> People { get; set; }
        public List<Company> Companies { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
