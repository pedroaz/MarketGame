using MarketGame.Core.Models.Companies;
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
        private GameState gameState;

        public GameState GameState { get => gameState; set => gameState = value; }
    }
}
