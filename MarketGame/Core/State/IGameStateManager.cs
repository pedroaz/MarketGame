using MarketGame.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketGame.Core.State
{
    public interface IGameStateManager
    {
        GameState GameState { get; set; }
    }
}
